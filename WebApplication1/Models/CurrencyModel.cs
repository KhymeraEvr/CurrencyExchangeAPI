using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Models
{   [JsonObject(MemberSerialization.OptIn)]
    public class CurrencyModel
    {
        [JsonProperty]
        public string CurrencyType { get; set; }
        [JsonProperty]
        public double ExchangeRate { get; set; }
    }
}
