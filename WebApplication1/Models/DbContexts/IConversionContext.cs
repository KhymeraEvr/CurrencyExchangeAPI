using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.DbContexts
{
    public interface IConversionContext
    {
        DbSet<ConvertModel> Converts { get; set; }
    }
}
