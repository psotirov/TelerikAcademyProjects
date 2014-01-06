using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Models;
using Students.Services.Models;
using Students.RepositoryLayer;
// using Students.DataLayer;

namespace Students.Services.Controllers
{
    public class SchoolsController : ApiController
    {
        // private StudentsEntities db = new StudentsEntities();
        private IRepository<School> repository;

        public SchoolsController(IRepository<School> repo)
        {
            this.repository = repo;
        }

        // GET api/Schools
        public IEnumerable<School> GetSchools()
        {
            return repository.All().AsEnumerable(); //db.Schools.AsEnumerable();
        }

        // GET api/Schools/5
        public SchoolModel GetSchool(int id)
        {
            School school = repository.Get(id); // db.Schools.Find(id);
            if (school == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new SchoolModel()
            {
                Name = school.Name,
                Location = school.Location,
                Students = (from studs in school.Students
                         select new StudentModel()
                         {
                             Name = studs.FirstName + " " + studs.LastName
                         }).AsEnumerable()
            };
        }

        // POST api/Schools
        public HttpResponseMessage PostSchool(SchoolModel school)
        {
            if (ModelState.IsValid)
            {
                var schoolTable = new School()
                {
                    Name = school.Name,
                    Location = school.Location
                };
                //db.Schools.Add(schoolModel);
                //db.SaveChanges();
                repository.Add(schoolTable);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, school);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = schoolTable.SchoolId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}