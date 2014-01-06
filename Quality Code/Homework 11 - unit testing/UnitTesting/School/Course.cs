using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolNS
{
    public class Course
    {
        public const int MaxStudents = 30;

        private string name;
        public List<Student> Students { get; set; }

        public Course(string name)
        {
            this.Students = new List<Student>();
            this.Name = name;
        }


        public string Name
        {
            get { return this.name; }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("Course Name is missing!");
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.Students.Contains(student))
            {
                throw new ArgumentException("The student joined this course already!");
            }

            if (this.Students.Count >= MaxStudents)
            {
                throw new ArgumentOutOfRangeException("The course is full!");
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.Students.Contains(student))
            {
                throw new ArgumentException("The student does not exist in this course!");
            }

            this.Students.Remove(student);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Course name {0}; ", this.Name));

            for (int i = 0; i < this.Students.Count; i++)
            {
                output.Append(this.Students[i]);
            }

            return output.ToString();
        }
    }
}
