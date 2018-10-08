using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Repository
{
    public class ConvertRepository : Repository<ConvertModel>,IConvertRepository
    {
        public ConvertRepository(ConversionsContext context) : base(context)
        {
        }

        public ConversionsContext conversionsContext => (ConversionsContext) Context;

        public IEnumerable<ConvertModel> GetDateConversions(string date)
        {
            return conversionsContext.Converts.Where(conv => conv.Date == date);
        }
    }
}
