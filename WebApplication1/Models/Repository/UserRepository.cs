using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Authentication;
using WebApplication1.Models.DbContexts;

namespace WebApplication1.Models.Repository
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
        public UserContext userContext => (UserContext)Context;
    }
}
