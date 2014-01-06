using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public abstract class Course
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        private List<string> students;

        public IList<string> Students 
        { 
            get { return this.students.GetRange(0, this.students.Count); }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("Null or empty list of students");
                } 
                this.students.AddRange(value);
            }
        }

        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.students = new List<string>();
        }

        public Course(string courseName, string teacherName)
            :this(courseName)
        {
            this.TeacherName = teacherName;
        }

        public Course(string courseName, string teacherName, List<string> students)
            :this(courseName, teacherName)
        {
            this.Students = students;
        }

        public void AddStudent(string name)
        {
            this.Students = new List<string>() {name};
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Course { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
