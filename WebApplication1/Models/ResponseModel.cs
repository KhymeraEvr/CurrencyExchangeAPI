using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
    [JsonObject]
    public class ResponseModel
    {
        public string ResponseError { get; set; }

        public string Base { get; set; }

        public string TimesStamp { get; set; }       
       
        public string Date { get; set; }
        
        public Dictionary<string,string> Rates { get; set; }

        public  List<CurrencyModel> DeserRates { get; set; } = new List<CurrencyModel>();

    }
}
