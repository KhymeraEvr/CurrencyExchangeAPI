using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Authentication;
using WebApplication1.Models.DbContexts;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConversionsContext _context;
        private readonly UserContext _userContext;
        public IConvertRepository Converts { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(IConversionContext context, IUserContext userContext)
        {
            _context = (ConversionsContext)context;
            _userContext = (UserContext)userContext;
            Converts = new ConvertRepository(_context);
            Users = new UserRepository(_userContext);
        }

        public void Dispose()
        {
            _context.Dispose();
            _userContext.Dispose();
        }

        public async Task Add(ConvertModel model)
        {
            Converts.Add(model);
            await Complete();
        }

        public async Task Add(User model)
        {
            Users.Add(model);
            await Complete();
        }


        public async Task<int> Complete()
        {
            await _userContext.SaveChangesAsync();
            return await _context.SaveChangesAsync();
        }
    }
}
