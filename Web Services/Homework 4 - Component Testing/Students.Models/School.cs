using System;
using System.Collections.Generic;

namespace Students.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public School()
        {
            this.Students = new HashSet<Student>();
        }
    }
}
