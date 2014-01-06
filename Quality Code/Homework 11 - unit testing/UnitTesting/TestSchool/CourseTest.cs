using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolNS;

namespace TestSchool
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseConstructorTestName()
        {
            Course course = new Course("QualityCode");
            Assert.AreEqual(course.Name, "QualityCode");
        }

        [TestMethod]
        public void CourseConstructorTestListStudents()
        {
            Course course = new Course("QualityCode");
            Student petar = new Student("Petar Petrov", 12345);
            course.AddStudent(petar);
            Assert.IsTrue(course.Students.Contains(petar));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestNullValue()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestEmptyString()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        public void AddStudentTestOneStudent()
        {
            Course course = new Course("QualityCode");
            course.AddStudent(new Student("Petar Petrov", 12345));
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        public void AddStudentTestTwoStudents()
        {
            Course course = new Course("QualityCode");
            course.AddStudent(new Student("Petar Petrov", 12345));
            course.AddStudent(new Student("Todor Todorov", 54321));
            Assert.IsTrue(course.Students.Count == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentTestExistingStudent()
        {
            Course course = new Course("QualityCode");
            Student petar = new Student("Petar Petrov", 12345);
            course.AddStudent(petar);
            course.AddStudent(petar);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudentTestMoreThanMaximumStudents()
        {
            Course course = new Course("QualityCode");
            for (int i = 0; i < 31; i++)
            {
                course.AddStudent(new Student("Petar Petrov " + i, 10000 + i));                
            }
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            Course course = new Course("QualityCode");
            course.AddStudent(new Student("Petar Petrov", 12345));
            Student todor = new Student("Todor Todorov", 54321);
            course.AddStudent(todor);
            course.RemoveStudent(todor);
            Assert.IsTrue(course.Students.Count == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingStudentTest()
        {
            Course course = new Course("QualityCode");
            Student petar = new Student("Petar Petrov", 12345);
            course.RemoveStudent(petar);
        }

        [TestMethod]
        public void ToStringTestOneStudent()
        {
            Course course = new Course("QualityCode");
            course.AddStudent(new Student("Petar Petrov", 12345));
            string expected = "Course name QualityCode; Student Petar Petrov, ID 12345; ";
            string result = course.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToStringTestTwoStudents()
        {
            Course course = new Course("QualityCode");
            course.AddStudent(new Student("Petar Petrov", 12345));
            course.AddStudent(new Student("Todor Todorov", 54321));
            string expected = "Course name QualityCode; Student Petar Petrov, ID 12345; Student Todor Todorov, ID 54321; ";
            string result = course.ToString();
            Assert.AreEqual(expected, result);
        }     
    }
}
