using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Common.Models;
using Microsoft.EntityFrameworkCore;


namespace backend.Common.Data
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<UserProfileTBL> UserProfileTBL { get; set; }
        public DbSet<UserTBL> UserTBL { get; set; }
        public DbSet<MutualFundOrderTBL> MutualFundOrderTBL { get; set; }
        public DbSet<PaymentTBL> PaymentTBL { get; set; }
        public string DbPath { get; }
        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultLocalConnection"));
        }

    }
}