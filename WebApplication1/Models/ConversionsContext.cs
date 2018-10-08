using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ConversionsContext : DbContext
    {
        public virtual DbSet<ConvertModel> Converts { get; set; }

        public ConversionsContext(DbContextOptions<ConversionsContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=SERVER NAME;Database=UserDB;Trusted_Connection=True;");
            }
        }
        public ConversionsContext() { }
    }
}
