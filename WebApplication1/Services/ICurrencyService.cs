using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.UnitOfWork;

namespace WebApplication1.Services
{
    public interface ICurrencyService
    {
        IUnitOfWork UnitOfWork { get; set; }
        Task<ResponseModel> GetLatestRates(string baseCurrency);
        Task<IEnumerable<CurrencyModel>> GetLatestEurRates();
        Task<ResponseModel> GetDateRates(string date);
        Task<ResponseModel> GetCertainRates(string[] rates);
        Task<ConvertModel> ConvertCurrency(string from, string to, double amount);
        Task<IEnumerable<ConvertModel>> getDateConversion(string date);
        Task<ResponseModel> GetCertainDateRate(string date, string baseCurrency);
    }
}
