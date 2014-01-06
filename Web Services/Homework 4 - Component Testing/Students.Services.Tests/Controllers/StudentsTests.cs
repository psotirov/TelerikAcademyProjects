using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Models;
using Students.RepositoryLayer;
using Students.Services.Models;
using Students.Services.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;


namespace Students.Services.Tests.Controllers
{
    [TestClass]
    public class StudentsTests
    {
        [TestMethod]
        public void GetAll_CheckForSingleStudentInRepository()
        {
            var repository = new FakeDbRepository<Student>();

            var stud = new Student()
            {
                FirstName = "First",
                LastName = "Last",
                Age = 100,
                Grade = 1
            };
            repository.entities.Add(stud);

            var studExpected = new StudentModel()
            {
                Name = "First Last"
            };
            var controller = new StudentsController(repository);

            var studentsModels = controller.GetStudents();
            Assert.IsTrue(studentsModels.Count() == 1);
            Assert.AreEqual(studExpected.Name, studentsModels.First().Name);
        }

        [TestMethod]
        public void GetById_CheckForSingleStudentInRepository()
        {
            var repository = new FakeDbRepository<Student>();

            var stud = new Student()
            {
                FirstName = "First",
                LastName = "Last",
                Age = 100,
                Grade = 1
            };
            repository.entities.Add(stud);

            var studExpected = new StudentModelDetails()
            {
                Name = "First Last",
                Age = 100,
                Grade = 1
            };
            var controller = new StudentsController(repository);

            var studentModel = controller.GetStudent(1);
            Assert.AreEqual(studExpected.Name, studentModel.Name);
            Assert.AreEqual(studExpected.Age, studentModel.Age);
            Assert.AreEqual(studExpected.Grade, studentModel.Grade);
            // Created Student should not have any assigned Mark
            Assert.IsTrue(studentModel.Marks.Count() == 0);
        }


        [TestMethod]
        public void Post_CheckForSingleStudentInRepository()
        {
            var repository = new FakeDbRepository<Student>();

            var studExpected = new StudentModelDetails()
            {
                Name = "First Last",
                Age = 100,
                Grade = 1
            };
            var controller = new StudentsController(repository);
            SetupController(controller);
            controller.PostStudent(studExpected);

            var studentModel = controller.GetStudent(1);
            Assert.AreEqual(studExpected.Name, studentModel.Name);
            Assert.AreEqual(studExpected.Age, studentModel.Age);
            Assert.AreEqual(studExpected.Grade, studentModel.Grade);
            // Created Student should not have any assigned Mark
            Assert.IsTrue(studentModel.Marks.Count() == 0);
        }

        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/Students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }
    }
}
