using System;

namespace _01_School
{
    public class Student : People
    {
        public int ClassID { get; set; }

        public Student(string name, int cID=0)
            : base(name)
        {
            this.ClassID = cID;
        }

        public override string ToString()
        {
            return "Student { Name: " + this.Name + ", ClassID: "+ ClassID + "}";
        }
    }
}
