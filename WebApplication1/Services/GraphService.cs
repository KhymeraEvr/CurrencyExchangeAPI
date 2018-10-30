using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GraphService : IGraphService
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMemoryCache _cache;

        public GraphService(ICurrencyService currencyService, IMemoryCache memoryCache)
        {
            _currencyService = currencyService;
            _cache = memoryCache;
        }

        public async Task<GraphModel> GetGraphData(string start, string currency, string baseCurrency)
        {
            string currentDate = (await _currencyService.GetLatestRates("EUR")).Date;
            YearMonthModel checkDate = new YearMonthModel(start);
            YearMonthModel today = new YearMonthModel(currentDate);

            List<string> dates = new List<string>();
            List<double> rates = new List<double>();

            while (!checkDate.Equals(today))
            {
                CurrencyModel wantedRate;
                if (!_cache.TryGetValue(currency + checkDate.ToString(), out wantedRate))
                {
                    ResponseModel dateRates =
                        await _currencyService.GetCertainDateRate(checkDate.ToString(), baseCurrency);                    
                    wantedRate = dateRates.DeserRates.FirstOrDefault(rate => rate.CurrencyType == currency);
                    if (wantedRate == null) return null;
                    _cache.Set(wantedRate.CurrencyType + checkDate.ToString(), wantedRate);
                }

                dates.Add(checkDate.ToString());
                rates.Add(wantedRate.ExchangeRate);
                checkDate.Month++;
            }

            GraphModel result = new GraphModel()
            {
                Dates = dates,
                Rates = rates,
                CurrencyType = currency,
                BaseCurrencyType = baseCurrency
            };
            return result;
        }

        public async Task<MultipleGraphModel> GetMultipleGraphData(string start, List<string> currencies, string baseCurrency)
        {
            MultipleGraphModel resultModel = new MultipleGraphModel();
            resultModel.BaseCurrencyType = baseCurrency;
            resultModel.GraphsNumb = currencies.Count;
            resultModel.Rates = new Dictionary<string, List<double>>();

            foreach (var currency in currencies)
            {
                GraphModel curResult = await GetGraphData(start, currency, baseCurrency);
                resultModel.Rates.Add(currency,curResult.Rates);
                if (resultModel.Dates == null)
                {
                    resultModel.Dates = curResult.Dates;
                }
            }

            return resultModel;
        }

    }
}
