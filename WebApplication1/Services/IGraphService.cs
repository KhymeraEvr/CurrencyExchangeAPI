using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IGraphService
    {
        Task<GraphModel> GetGraphData(string start, string currency, string baseCurrency);
        Task<MultipleGraphModel> GetMultipleGraphData(string start, List<string> currencies, string baseCurrency);
    }
}
