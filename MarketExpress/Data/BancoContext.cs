using MarketExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MarketExpress.Data
{
    public class BancoContext : DbContext

    {
        public BancoContext(DbContextOptions<BancoContext>options) : base(options) { }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<SalesModel> Sales { get; set; }
        
        public DbSet<UserModel> Users { get; set; }

    }
}
