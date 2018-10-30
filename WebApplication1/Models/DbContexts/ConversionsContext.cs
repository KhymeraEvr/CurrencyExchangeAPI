using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DbContexts;

namespace WebApplication1.Models
{
    public class ConversionsContext : DbContext, IConversionContext
    {
        public virtual DbSet<ConvertModel> Converts { get; set; }

        public ConversionsContext(DbContextOptions<ConversionsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
       
    }
}
 