using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Students.Models;
using Students.RepositoryLayer;
using Students.Services.Controllers;

namespace Students.IntegrationTests
{
    class TestDependencyResolver<T> : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(new FakeDbRepository<Student>());
            }

            if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(new FakeDbRepository<School>());
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
