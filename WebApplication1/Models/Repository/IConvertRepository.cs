using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Repository
{
    public interface IConvertRepository : IRepository<ConvertModel>
    {
        IEnumerable<ConvertModel> GetDateConversions(string date);
    }
}
