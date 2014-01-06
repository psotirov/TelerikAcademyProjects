using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Models;
using Students.Services.Models;
using Students.RepositoryLayer;
// using Students.DataLayer;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        // private StudentsEntities db = new StudentsEntities();
        private IRepository<Student> repository;

        public StudentsController(IRepository<Student> repo)
        {
            this.repository = repo;
        }

        // GET api/Students
        public IEnumerable<StudentModel> GetStudents()
        {
            return (from students in repository.All() //db.Students
                    select new StudentModel()
                    {
                        Name = students.FirstName + " " + students.LastName,
                    })
                    .AsEnumerable();
        }

        // GET api/Students/id
        public StudentModelDetails GetStudent(int id)
        {
            Student student = repository.Get(id); //db.Students.Find(id);
            if (student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new StudentModelDetails()
                    {
                        Name = student.FirstName + " " + student.LastName,
                        Age = student.Age,
                        Grade = student.Grade,
                        Marks = (from marks in student.Marks
                                 select new MarkModel()
                                 {
                                     Subject = marks.Subject,
                                     Score = marks.Score
                                 })
                                 .AsEnumerable()
                    };
        }

        // GET api/Students/subject=xxx&value=z.zz
        public IEnumerable<StudentModel> GetStudentsData(string subject, float value)
        {
            //IEnumerable<StudentModel> students =
            //    (from studs in db.Students.Include("Marks")
            //     where (studs.Marks.Any(m => m.Subject == subject && m.Score == value))
            //     select new StudentModel()
            //     {
            //         Name = studs.FirstName + " " + studs.LastName
            //     }).AsEnumerable();

            //var query = repository.Find((x, i) => x.Marks.Any(m => m.Subject == subject && m.Score == value)); // does not work
            var query = repository.All().Where(x => x.Marks.Any(m => m.Subject == subject && m.Score == value));
            IEnumerable<StudentModel> students = query
                 .Select(s => new StudentModel()
                 {
                     Name = s.FirstName + " " + s.LastName
                 }).AsEnumerable();

            if (students == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return students;
        }

        // POST api/Students
        public HttpResponseMessage PostStudent(StudentModelDetails student)
        {
            if (ModelState.IsValid)
            {
                if (student == null || student.Name == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Wrong input data");
                }

                string[] names = student.Name.Split(new char[] {' '});
                string firstName = names[0];
                string lastName = (names.Length > 1)?names[1]:"";
                var stud = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = student.Age,
                    Grade = student.Grade
                };
                //db.Students.Add(stud);
                //db.SaveChanges();
                repository.Add(stud);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = stud.StudentId }));
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