using System;
using System.Data.Entity;
using BookstoreLogs.Model;

namespace BookstoreLogs.Data
{
    public class BookstoreLogsEntities : DbContext
    {
        public DbSet<SearchLog> SearchLogs { get; set; }

        BookstoreLogsEntities()
            : base("Data Source=localhost;Initial Catalog=StudentSystem;Integrated Security=True")
        {
        }
    }
}