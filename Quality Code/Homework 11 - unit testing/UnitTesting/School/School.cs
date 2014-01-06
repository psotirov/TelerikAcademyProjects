using System;
using System.Collections.Generic;

namespace SchoolNS
{
    public class School
    {
        public List<Course> Courses { get; set; }

        public School()
        {
            this.Courses = new List<Course>();
        }


        public void AddCourse(Course course)
        {
            if (this.Courses.Contains(course))
            {
                throw new ArgumentException("The course exists already!");
            }

            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            if (!this.Courses.Contains(course))
            {
                throw new ArgumentException("The course does not exist in this school!");
            }

            this.Courses.Remove(course);
        }
    }
}
