using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IConvertRepository Converts { get; }
        int Complete();
    }
}
