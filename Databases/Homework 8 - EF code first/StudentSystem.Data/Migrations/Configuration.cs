namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Materials.AddOrUpdate(m => m.Description,
                new Material { Type = MaterialType.Presentation, Description = "JavaScript OOP" }, 
                new Material { Type = MaterialType.Demo, Description = "JavaScript Closures" }, 
                new Material { Type = MaterialType.Presentation, Description = "C# inheritance" }, 
                new Material { Type = MaterialType.Demo, Description = "Bank System" }, 
                new Material { Type = MaterialType.Presentation, Description = "Entity Framework Code First" }, 
                new Material { Type = MaterialType.Video, Description = "Forum Database" });

            context.Courses.AddOrUpdate(c => c.Name, 
                new Course { Name = "JavaScript", TrainerName = "Doncho Minkov" },
                new Course { Name = "C#", TrainerName = "Nikolay Kostov" },
                new Course { Name = "Databases", TrainerName = "Svetlin Nakov" });
            
            context.Students.AddOrUpdate(s => s.Name,
                new Student { Name = "Pesho Peshev", Number = "1000001" },
                new Student { Name = "Gosho Goshov", Number = "2000002" },
                new Student { Name = "Tosho Toshev", Number = "3000003" });

            context.SaveChanges();

            context.Courses
                .Where(x => x.Name == "JavaScript")
                .First()
                .Materials.Add(context.Materials.Where(m => m.Description == "JavaScript OOP").First());

            context.Courses
                .Where(x => x.Name == "JavaScript")
                .First()
                .Materials.Add(context.Materials.Where(m => m.Description == "JavaScript Closures").First());

            context.Courses
                .Where(x => x.Name == "C#")
                .First()
                .Materials.Add(context.Materials.Where(m => m.Description == "C# inheritance").First());
            
            context.Courses
                .Where(x => x.Name == "C#")
                .First()
                .Materials.Add(context.Materials.Where(m => m.Description == "Bank System").First());
            
            context.Courses
                .Where(x => x.Name == "Databases")
                .First()
                .Materials.Add(context.Materials.Where(m => m.Description == "Entity Framework Code First").First());
            
            context.Courses
                .Where(x => x.Name == "Databases")
                .First()
                .Materials.Add(context.Materials.Where(m => m.Description == "Forum Database").First());


            context.Students
                .Where(x => x.Number == "1000001")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "C#").First());

            context.Students
                .Where(x => x.Number == "1000001")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "Databases").First());

            context.Students
                .Where(x => x.Number == "2000002")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "JavaScript").First());

            context.Students
                .Where(x => x.Number == "3000003")
                .First()
                .Courses.Add(context.Courses.Where(c => c.Name == "Databases").First());

            context.SaveChanges();
        }
    }
}
