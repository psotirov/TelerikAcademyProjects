using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolNS;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolConstructorTest()
        {
            School school = new School();
            Assert.IsNotNull(school);
        }

        [TestMethod]
        public void AddCourseTest()
        {
            Course course = new Course("QualityCode");
            School school = new School();
            school.AddCourse(course);
            Assert.AreEqual(course.Name, school.Courses[0].Name);
        }

        [TestMethod]
        public void RemoveCourseTest()
        {
            School school = new School();
            Course course = new Course("QualityCode");
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.IsTrue(school.Courses.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingCourseTest()
        {
            School school = new School();
            school.RemoveCourse(new Course("QualityCode"));
        }
    }
}
