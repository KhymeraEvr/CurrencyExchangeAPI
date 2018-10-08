using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{


    [Route("api/[controller]")]
    public class RatesController : Controller
    {
        CurrencyService serv = new CurrencyService();
        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<CurrencyModel>> Get()
        {
            return await serv.GetLatestEurRates();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            ResponseModel response = await serv.GetLatestRates(id);
            return Ok(response.DeserRates);
        }

        [HttpGet("date/{date}")]
        public async Task<IEnumerable<CurrencyModel>> GetDateRate(string date)
        {
            ResponseModel response = await serv.GetDateRates(date);
            return response.DeserRates;
        }

        [HttpGet("select/{id1}/{id2}")]
        public async Task<IActionResult> GetCertainRates(string id1, string id2)
        {
            ResponseModel response = await serv.GetCertainRates(new string[] { id1, id2 });
            return Ok(response);
        }

        [Route("{convertFrom}/{convertTo}/{amount}")]
        public async Task<ConvertModel> Convert(string convertFrom, string convertTo, double amount)
        {
            return await serv.ConvertCurrency(convertFrom, convertTo, amount);
        }
    }
}
