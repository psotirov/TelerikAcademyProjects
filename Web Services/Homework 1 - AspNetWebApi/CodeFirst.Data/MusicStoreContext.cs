namespace CodeFirst.Data
{
    using System.Data.Entity;

    using CodeFirst.Models;

    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext()
            : base("Data Source=localhost;Initial Catalog=MusicStore;Integrated Security=True")
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

    }
}
