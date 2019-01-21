using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models.UnitOfWork;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        IUnitOfWork UnitOfWork { get; set; }
        Task<ClaimsIdentity> GetIdentity(string username, string password);
        string GetToken(ClaimsIdentity identity);
        Task<bool> UserNameIsAvailable(string name);
    }
}
