using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CurrencyService
    {

        private readonly string accesCode = "2792eb83493ce473f505a52aab1e9e53";
        private readonly string baseUrl = "http://data.fixer.io/api/latest?access_key=2792eb83493ce473f505a52aab1e9e53";


        
        public ResponseModel GetLatestEurRates()
        {
            string response =  getResponse(baseUrl + "&symbols=USD,AUD,CAD,PLN,MXN&format=1");
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            foreach (var toDesr in result.Rates)
            {
                result.DeserRates.Add(new CurrencyModel { CurrencyType = toDesr.Key, ExchangeRate = Convert.ToDouble(toDesr.Value.Replace('.', ',')) });
            }
            return result;
        }

        public ResponseModel GetLatestRates(string baseCurrency)
        {
            string response =  getResponse(baseUrl + "&base=" + baseCurrency.ToUpper() + "&symbols=USD,AUD,CAD,PLN,MXN&format=1");
            var result = JsonConvert.DeserializeObject<ResponseModel>(response);
            foreach (var toDesr in result.Rates)
            {
                result.DeserRates.Add(new CurrencyModel { CurrencyType = toDesr.Key, ExchangeRate = Convert.ToDouble(toDesr.Value.Replace('.', ',')) });
            }
            return result;
        }

        public ConvertModel ConvertCurrency(string from, string to, double amount)
        {
            string response = getResponse(baseUrl + "&from=" + from.ToUpper() + "&to=" + to.ToUpper() + "&amount=" + amount);

            var result = JsonConvert.DeserializeObject<ConvertModel>(response);
            return result;
        }

        private string getResponse(string url)
        {
            HttpClient client = new HttpClient();
            var response =
                client.GetAsync(url)
                    .Result;

            response.EnsureSuccessStatusCode();

            return  response.Content.ReadAsStringAsync().Result;
            
        }
    }
}
