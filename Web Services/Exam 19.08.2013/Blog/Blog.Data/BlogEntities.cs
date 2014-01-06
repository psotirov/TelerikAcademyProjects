using System;
using System.Data.Entity;
using Blog.Models;

namespace Blog.Data
{
    public class BlogEntities: DbContext
    {
        public BlogEntities()
            : base("Data Source=localhost;Initial Catalog=BlogDB;Integrated Security=True")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(usr => usr.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                 .Property(usr => usr.AuthCode)
                 .IsFixedLength()
                 .HasMaxLength(40);

            base.OnModelCreating(modelBuilder);
        }
    }
}
