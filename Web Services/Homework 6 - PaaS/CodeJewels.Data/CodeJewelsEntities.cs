using System;
using System.Data.Entity;
using CodeJewels.Models;

namespace CodeJewels.DataLayer
{
    public class CodeJewelsEntities : DbContext
    {
        public CodeJewelsEntities()
            : base("Data Source=localhost;Initial Catalog=CodeJewels;Integrated Security=True")
        {
        }

        public DbSet<CodeJewel> CodeJewels { get; set; }
        public DbSet<Category> JewelCategories { get; set; }
    }
}