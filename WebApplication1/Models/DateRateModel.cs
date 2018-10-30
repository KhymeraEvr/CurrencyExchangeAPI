using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DateRateModel
    {
        public string CurrencyType { get; set; }
        public string BaseCurrency { get; set; }
        public Dictionary<string,double> RateValues { get; set; }
    }
}
