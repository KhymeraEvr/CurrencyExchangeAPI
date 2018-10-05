using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
   

    [Route("api/[controller]")]
    public class RatesController : Controller
    {
        CurrencyService serv = new CurrencyService();
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CurrencyModel> Get()
        {
            return serv.GetLatestEurRates().DeserRates;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IEnumerable<CurrencyModel> Get(string id)
        {
            return serv.GetLatestRates(id).DeserRates;
        }

        [Route("{convertFrom}/{convertTo}/{amount}")]
        public ConvertModel Convert (string convertFrom, string convertTo, double amount)
        {
            return serv.ConvertCurrency(convertFrom, convertTo, amount);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
