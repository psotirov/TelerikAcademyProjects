using System;
using System.Data.Entity;
using Supermarket.Models;
using Supermarket.Data.MySql;

namespace Supermarket.Data
{
    public class SupermarketEntities : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<SuperMarket> SuperMarkets { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public SupermarketEntities()
            : base("Data Source=localhost;Initial Catalog=SupermarketSystem;Integrated Security=True")
        {
        }
    }
}
