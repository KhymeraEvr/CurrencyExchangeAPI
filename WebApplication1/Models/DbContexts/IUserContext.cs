using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Authentication;

namespace WebApplication1.Models.DbContexts
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }
    }
}
