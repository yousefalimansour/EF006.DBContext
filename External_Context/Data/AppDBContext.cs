using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF006.DBContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF006.DBContext.Data
{
    public class AppDBContext : DbContext 
    {
        public DbSet<Wallet> wallets { get; set; } = null!;
         public AppDBContext(DbContextOptions options)
            : base(options)
         {
            
         }
       
    } 
}
