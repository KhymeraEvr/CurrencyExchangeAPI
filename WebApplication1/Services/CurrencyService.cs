using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using WebApplication1.Models;
using WebApplication1.Models.UnitOfWork;

namespace WebApplication1.Services
{
    public class CurrencyService
    {

        private readonly string accesCode = "2792eb83493ce473f505a52aab1e9e53";
        private readonly string baseUrl = "https://api.exchangeratesapi.io/latest";
        private UnitOfWork unitOfWork = new UnitOfWork(new ConversionsContext());


        public async Task<IEnumerable<CurrencyModel>> GetLatestEurRates()
        {
            string response = await getResponse(baseUrl + "?symbols=USD,AUD,CAD,PLN,MXN&format=1");
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            foreach (var toDesr in result.Rates)
            {
                result.DeserRates.Add(new CurrencyModel { CurrencyType = toDesr.Key, ExchangeRate = Convert.ToDouble(toDesr.Value.Replace('.', ',')) });
            }
            return result.DeserRates;
        }

        public async Task<ResponseModel> GetLatestRates(string baseCurrency)
        {
            string response =  await getResponse(baseUrl + "?base=" + baseCurrency.ToUpper());
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            if (result.ResponseError != null)
            {
                return null;
            }
            foreach (var toDesr in result.Rates)
            {
                result.DeserRates.Add(new CurrencyModel { CurrencyType = toDesr.Key, ExchangeRate = Convert.ToDouble(toDesr.Value.Replace('.', ',')) });
            }
            return result;
        }


        public async Task<ResponseModel> GetDateRates(string date)
        {
            string url = baseUrl.Remove(baseUrl.Length - 6) + date;
            string response = await getResponse(url);
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            if (result.ResponseError != null)
            {
                return null;
            }

            foreach (var toDesr in result.Rates)
            {
                result.DeserRates.Add(new CurrencyModel { CurrencyType = toDesr.Key, ExchangeRate = Convert.ToDouble(toDesr.Value.Replace('.', ',')) });
            }
            return result;
        }

        public async Task <ResponseModel> GetCertainRates(string[] rates)
        {
            string url = baseUrl + "?symbols=";
            foreach (var rate in rates)
            {
                url += rate.ToUpper() + ",";
            }

            url = url.Remove(url.Length - 1);
            url += "&format=1";
            string response = await getResponse(url);
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
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
                double result = rates.DeserRates.Find(cur => cur.CurrencyType == from.ToUpper()).ExchangeRate *
                                rates.DeserRates.Find(cur => cur.CurrencyType == to.ToUpper()).ExchangeRate *
                    amount;
                ConvertModel convert = new ConvertModel { Date = rates.Date, Result = result };
                //unitOfWork.Converts.Add(convert);
                //unitOfWork.Complete();
                return convert;
            }

            return null;
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
