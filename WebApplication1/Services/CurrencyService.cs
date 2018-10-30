using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Models.UnitOfWork;

namespace WebApplication1.Services
{
    public class CurrencyService : ICurrencyService
    {

        private readonly string baseUrl = "https://api.exchangeratesapi.io/latest";

        public IUnitOfWork UnitOfWork { get; set; }

        public CurrencyService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CurrencyModel>> GetLatestEurRates()
        {
            string response = await getResponse(baseUrl + "?symbols=USD,AUD,CAD,PLN,MXN&format=1");
            var result = DeserResponse(response);
            return result.DeserRates;
        }

        public async Task<ResponseModel> GetLatestRates(string baseCurrency)
        {
            string response = await getResponse(baseUrl + "?base=" + baseCurrency.ToUpper());
            var result = DeserResponse(response);
            result.DeserRates.RemoveAll(rate => rate.CurrencyType == baseCurrency.ToUpper());
            return result;
        }


        public async Task<ResponseModel> GetDateRates(string date)
        {
            string url = baseUrl.Remove(baseUrl.Length - 6) + date;
            string response = await getResponse(url);
            var result = DeserResponse(response);
            result.DeserRates.RemoveAll(rate => rate.CurrencyType == "EUR");
            return result;
        }

        private ResponseModel DeserResponse(string response)
        {
            ResponseModel result = JsonConvert.DeserializeObject<ResponseModel>(response);
            if (result.ResponseError != null)
            {
                return null;
            }

            foreach (var toDesr in result.Rates)
            {
                result.DeserRates.Add(new CurrencyModel { CurrencyType = toDesr.Key,
                    ExchangeRate = Convert.ToDouble(toDesr.Value.Replace('.', ',')) });
            }

            result.DeserRates = result.DeserRates.OrderBy(cur => cur.CurrencyType).ToList();
            return result;
        }

        public async Task<ResponseModel> GetCertainRates(string[] rates)
        {
            StringBuilder url = new StringBuilder();
            url.Append(baseUrl + "?symbols=");
            foreach (var rate in rates)
            {
                url.Append(rate.ToUpper() + ","); // stringbuilder
            }
            url.Remove(url.Length - 1,1);
            url.Append("&format=1");
            string response = await getResponse(url.ToString());
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            if (result.ResponseError != null)
            {
                return null;
            }
            return result;
        }

        public async Task<ResponseModel> GetCertainDateRate(string date,string baseCurrency)
        {
            string url = baseUrl.Remove(baseUrl.Length - 6) + date;
            url +="?base=" + baseCurrency.ToUpper();
            string response = await getResponse(url);
            var result = DeserResponse(response);
            if (result.ResponseError != null)
            {
                return null;
            }
            return result;
        }

        public async Task<ConvertModel> ConvertCurrency(string from, string to, double amount)
        {
            ResponseModel rates = await GetLatestRates(from);
            if (rates != null && rates.DeserRates.Find(cur => cur.CurrencyType == to.ToUpper()) != null)
            {
                double intoRate = rates.DeserRates.Find(cur => cur.CurrencyType == to.ToUpper()).ExchangeRate;
                double result = intoRate * amount;
                ConvertModel convert = new ConvertModel { Date = rates.Date, Result = result, From = from, Into = to };
                UnitOfWork.Converts.Add(convert);
                await UnitOfWork.Complete();
                return convert;
            }

            return null;
        }

        public async Task<IEnumerable<ConvertModel>> getDateConversion(string date)
        {
            return await UnitOfWork.Converts.GetDateConversions(date);
        }

        private async Task<string> getResponse(string url)
        {
            HttpClient client = new HttpClient();
            var response =
                await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
