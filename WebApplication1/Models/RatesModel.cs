using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RatesModel
    {

        public string Base { get; set; }

        public string Date { get; set; }

        public List<CurrencyModel> DeserRates { get; set; } = new List<CurrencyModel>();
    }
}
