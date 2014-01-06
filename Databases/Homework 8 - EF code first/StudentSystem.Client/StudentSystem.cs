using System;
using System.Data.Entity;
using StudentSystem.Models;
using StudentSystem.Data;
using StudentSystem.Data.Migrations;


namespace StudentSystem.Client
{
    public class StudentSystem
    {
        // In order to enable migrations set <Project>.Data as current project
        // Enter in Package Manager Console PM> Enable-Migrations -EnableAutomaticMigrations
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemEntities, Configuration>());

            Console.WriteLine("Creating Database \"StudentSystem\"");
            var ctx = new StudentSystemEntities();
            ctx.Homeworks.Add(new Homework { Content = "First Homework", TimeSent = DateTime.Now });
            ctx.SaveChanges();
        }
    }
}
