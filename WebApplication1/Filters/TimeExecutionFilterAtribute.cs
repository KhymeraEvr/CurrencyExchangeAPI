using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication1.Filters
{
    public class TimeExecutionFilterAtribute : Attribute, IResultFilter
    {
        private DateTime _start;
        public void OnResultExecuting(ResultExecutingContext context)
        {
            _start = DateTime.Now;
        }

        public async void OnResultExecuted(ResultExecutedContext context)
        {
            DateTime fin = DateTime.Now;
            double timeElapsed = fin.Subtract(_start).TotalSeconds;
            await context.HttpContext.Response.WriteAsync($"Result took {timeElapsed} seconds");
        }
    }
}
