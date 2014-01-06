using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Students.Models;
using Students.RepositoryLayer;
using Students.Services.Controllers;
using Students.DataLayer;
using System.Data.Entity;

namespace Students.Services.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext dbContext = new StudentsEntities();

        private static IRepository<School> schoolsRepository = new EfDbRepository<School>(dbContext);
        private static IRepository<Student> studentsRepository = new EfDbRepository<Student>(dbContext);
        
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(studentsRepository);
            }

            if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(schoolsRepository);
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}