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
    }
}
