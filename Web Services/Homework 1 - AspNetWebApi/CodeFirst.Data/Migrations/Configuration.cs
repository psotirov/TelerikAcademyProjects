namespace CodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using CodeFirst.Models;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MusicStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        // This method will be called after migrating to the latest version.
        protected override void Seed(MusicStoreContext context)
        {
            var volodya = from a in context.Artists
                          where a.Name == "Volodya Stoyanov"
                          select a;

            if (volodya == null)
            {
                context.Artists.AddOrUpdate(new Artist { Name = "Volodya Stoyanov", Country = "Bulgaria", BirthDate = new DateTime(1960, 12, 3) });
                context.SaveChanges();
            }
        }
    }
}