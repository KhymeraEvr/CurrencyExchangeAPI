using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Models.Repository
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
