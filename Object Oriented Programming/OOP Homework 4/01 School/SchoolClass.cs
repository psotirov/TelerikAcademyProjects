using System;
using System.Collections.Generic;

namespace _01_School
{
    public class SchoolClass
    {
        public string ClassID { get; set; }
        public string Comment { get; set; }
        // for example below lists could be grouped in:
        // public List<People> Participants;
        public List<Teacher> Teachers;
        public List<Student> Students;

        public SchoolClass(string cID, Teacher teacher = null, Student student = null)
        {
            this.ClassID = cID;
            this.Teachers = new List<Teacher>();
            if (teacher != null) this.Teachers.Add(teacher);
            this.Students = new List<Student>();
            if (student != null) this.Students.Add(student);
        }

        public override string ToString()
        {
            string result = "SchoolClass { Class ID:" + this.ClassID + ", List of Students:\r\n";
            foreach (Student s in this.Students)
            {
                result += s.ToString() + ";\r\n";
            }
            result += ", List of Teachers:\r\n";
            foreach (Teacher t in this.Teachers)
            {
                result += t.ToString() + ";\r\n";
            }
            return result + "}\r\n";
        }
    }
}
