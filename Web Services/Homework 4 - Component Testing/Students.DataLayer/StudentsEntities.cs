using System;
using System.Data.Entity;
using Students.Models;

namespace Students.DataLayer
{
    public class StudentsEntities : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public StudentsEntities()
            : base("Data Source=localhost;Initial Catalog=Students;Integrated Security=True")
        {
        }
    }
}
