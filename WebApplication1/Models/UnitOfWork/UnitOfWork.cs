using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConversionsContext context;

        public UnitOfWork(ConversionsContext context)
        {
            this.context = context;
            Converts = new ConvertRepository(context);
        }

        public void Dispose()
        {
           context.Dispose();
        }

        public IConvertRepository Converts { get; }
        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
