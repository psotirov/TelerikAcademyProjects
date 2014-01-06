using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolNS;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void StudentConstructorTestName()
        {
            string name = "Petar Petrov";
            int id = 12345;
            Student student = new Student(name, id);
            Assert.AreEqual(student.Name, "Petar Petrov");
        }

        [TestMethod]
        public void StudentConstructorTestid()
        {
            string name = "Petar Petrov";
            int id = 12345;
            Student student = new Student(name, id);
            Assert.AreEqual(student.ID, 12345);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestNullValue()
        {
            string name = null;
            int id = 12345;
            Student student = new Student(name, id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameTestEmptyString()
        {
            string name = string.Empty;
            int id = 12345;
            Student student = new Student(name, id);
        }

        [TestMethod]
        public void idTestStartValue()
        {
            string name = "Petar Petrov";
            int id = 10000;
            Student student = new Student(name, id);
            Assert.AreEqual(student.ID, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void idTestBelowStartValue()
        {
            string name = "Petar Petrov";
            int id = 9999;
            Student student = new Student(name, id);
        }

        [TestMethod]
        public void idTestEndValue()
        {
            string name = "Petar Petrov";
            int id = 99999;
            Student student = new Student(name, id);
            Assert.AreEqual(student.ID, 99999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void idTestAboveEndValue()
        {
            string name = "Petar Petrov";
            int id = 100000;
            Student student = new Student(name, id);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string name = "Petar Petrov";
            int id = 12345;
            Student student = new Student(name, id);
            string expected = "Student Petar Petrov, ID 12345; ";
            string result = student.ToString();
            Assert.AreEqual(expected, result);
        }
    }
}
