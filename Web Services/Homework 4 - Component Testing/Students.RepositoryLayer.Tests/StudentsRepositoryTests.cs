using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.DataLayer;
using Students.Models;
using Students.RepositoryLayer;
using System.Data.Entity;

namespace Students.RepositoryLayer.Tests
{
    [TestClass]
    public class StudentsRepositoryTests
    {
        private DbContext dbContext { get; set; }

        private IRepository<Student> studentsRepository { get; set; }

        private static TransactionScope tranScope;

        public StudentsRepositoryTests()
        {
            this.dbContext = new StudentsEntities();
            this.studentsRepository = new EfDbRepository<Student>(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void AddToDb_CheckConnection()
        {
            var stud = new Student()
            {
                FirstName = "First",
                LastName = "Last",
                Age = 100,
                Grade = 1
            };
            dbContext.Set<Student>().Add(stud);
            dbContext.SaveChanges();
            Assert.IsTrue(stud.StudentId > 0);
        }

        [TestMethod]
        public void Add_CheckForValidStudentId()
        {
            var stud = new Student()
            {
                FirstName = "First",
                LastName = "Last",
                Age = 100,
                Grade = 1
            };
            var createdStud = this.studentsRepository.Add(stud);
            Assert.IsTrue(createdStud.StudentId != 0);
        }

        [TestMethod]
        public void Add_CheckForValidData()
        {
            var stud = new Student()
            {
                FirstName = "First",
                LastName = "Last",
                Age = 100,
                Grade = 1
            };
            var createdStud = this.studentsRepository.Add(stud);
            Assert.AreEqual(stud.FirstName, createdStud.FirstName);
            Assert.AreEqual(stud.LastName, createdStud.LastName);
            Assert.AreEqual(stud.Age, createdStud.Age);
            Assert.AreEqual(stud.Grade, createdStud.Grade);
            // Created Student should not have assigned School
            Assert.IsNull(createdStud.School);
            // Created Student should not have any assigned Mark
            Assert.IsTrue(createdStud.Marks.Count == 0);
        }
    }
}
