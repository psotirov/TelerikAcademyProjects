using System;
using System.Data.Entity;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public class StudentSystemEntities : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Student> Students { get; set; }

        public StudentSystemEntities()
            : base("Data Source=localhost;Initial Catalog=StudentSystem;Integrated Security=True")
        {
        }
    }
}
