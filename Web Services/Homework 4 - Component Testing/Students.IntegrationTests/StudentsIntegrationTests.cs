using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Models;
using Students.Services.Models;

namespace Students.IntegrationTests
{
    [TestClass]
    public class StudentsIntegrationTests
    {
        [TestMethod]
        public void GetAll_CheckForStatusCode200()
        {
            var server = new FakeHTTPServer<Student>("http://localhost/");

            var response = server.CreateGetRequest("api/Students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            // Response should have Content
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Post_CheckForStatusCode201()
        {
            var server = new FakeHTTPServer<Student>("http://localhost/");

            var newStudent = new StudentModelDetails()
                {
                    Name = "First Last",
                    Age = 100,
                    Grade = 1
                };
            var response = server.CreatePostRequest("api/Students", newStudent);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostEmptyStudent_CheckForStatusCode400()
        {
            var server = new FakeHTTPServer<Student>("http://localhost/");
            var newStudent = new StudentModelDetails();
            var response = server.CreatePostRequest("api/Students", newStudent);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
