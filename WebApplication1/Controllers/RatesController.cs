using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Newtonsoft.Json;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.UnitOfWork;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class RatesController : Controller
    {
        public RatesController(ICurrencyService service,IGraphService graphService)
        {
            _service = service;
            _graphService = graphService; 
        }

        private readonly ICurrencyService _service;
        private readonly IGraphService _graphService;
     
        // GET: api/rates 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetLatestEurRates());
        }

        // GET api/rates/{ID}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            ResponseModel response = await _service.GetLatestRates(id);
            if (response == null) return NotFound();
            return Ok(response.DeserRates);
        }

        // GET api/rates/date/{date}
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetDateRate(string date)
        {
            ResponseModel response = await _service.GetDateRates(date);
            if (response == null)
                return NotFound();

            RatesModel result = Mapper.Map<RatesModel>(response);
            return Ok(result.DeserRates);
        }

        // GET api/rates/Graph/{baseCur}/{checkCur}/{date}
        //[TimeExecutionFilterAtribute]
        [HttpGet("Graph/{baseCur}/{checkCur}/{date}")]
        public async Task<IActionResult> GetGraphTable(string baseCur, string checkCur, string date)
        {
            GraphModel result = await _graphService.GetGraphData(date, checkCur, baseCur);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost("Graph/{baseCur}/{date}")]
        public async Task<IActionResult> GetMultipleGraphTable(string baseCur,[FromBody] GraphRequestModel checkCur, string date)
        {
           
            if (checkCur == null)
            {
                return BadRequest();
            }
            MultipleGraphModel result = await _graphService.GetMultipleGraphData(date, checkCur.rates, baseCur);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET api/rates/select/converts/{date}
        [HttpGet("select/converts/{date}")]
        public async Task<IActionResult> GetRatesFromDate(string date)
        {
            IEnumerable<ConvertModel> convert = await _service.getDateConversion(date);
            if (convert == null) return NotFound();
            return Ok(convert);
        }

        // GET api/rates/select/{id}/{id2}
        [HttpGet("select/{id1}/{id2}")]
        public async Task<IActionResult> GetCertainRates(string id1, string id2)
        {
            ResponseModel response = await _service.GetCertainRates(new string[] { id1, id2 });
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        // GET api/rates/{convertFrom}/{convertTo}/{amount}
        [Authorize(Roles = "user,admin")]
        [Route("{convertFrom}/{convertTo}/{amount}")]
        public async Task<IActionResult> Convert(string convertFrom, string convertTo, double amount)
        {
            var response = await _service.ConvertCurrency(convertFrom, convertTo, amount);
            if (response == null) return NotFound();
            return Ok(response);
        }

        // POST api/rates/converts
        [Authorize(Roles = "admin")]
        [HttpPost("converts")]
        public async Task<IActionResult> AddCustomConvert([FromBody] ConvertModel conv)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _service.UnitOfWork.Add(conv);
            return Ok();
        }

        
        // PUT api/rates/converts/{ID}
        [Authorize(Roles = "admin")]
        [HttpPut("converts/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ConvertModel newItem)
        {
         
            if (!ModelState.IsValid) return BadRequest();
            var item = await _service.UnitOfWork.Converts.FindFirst(conv => conv.Id == id);
            if (item == null) return NotFound();

            item.Result = newItem.Result;
            item.Date = newItem.Date;
            item.From = newItem.From;
            item.Into = newItem.Into;

            await _service.UnitOfWork.Complete();
            return NoContent();
        }

        // PATCH api/rates/converts/{ID}
        [Authorize(Roles = "admin")]
        [HttpPatch("converts/{id}")]
        public async Task<IActionResult> PartialUpdate(int id, [FromBody] JsonPatchDocument<ConvertModel> patchDoc)
        {
            var item = await _service.UnitOfWork.Converts.FindFirst(conv => conv.Id == id);
            if (item == null) return NotFound();
            patchDoc.ApplyTo(item);
            await _service.UnitOfWork.Complete();
            return NoContent();
        }

        // DELETE api/rates/{ID}        
        [Authorize(Roles = "admin")]
        [HttpDelete("converts/{id}")]
        public async Task<IActionResult> DeleteConvert(int id)
        {
            var item = await _service.UnitOfWork.Converts.FindFirst(conv => conv.Id == id);
            if (item == null) return NotFound();
            _service.UnitOfWork.Converts.Remove(item);
            await _service.UnitOfWork.Complete();
            return NoContent();
        }
    }
}
