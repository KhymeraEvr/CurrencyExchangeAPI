using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GraphModel
    {
        public string CurrencyType { get; set; }
        public string BaseCurrencyType { get; set; }
        public List<string> Dates { get; set; }
        public List<double> Rates { get; set; }
    }
}
