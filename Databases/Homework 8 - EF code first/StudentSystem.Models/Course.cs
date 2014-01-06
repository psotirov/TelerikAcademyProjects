using System;
using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string TrainerName { get; set; }

        private ICollection<Student> students;
        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        private ICollection<Material> materials;
        public virtual ICollection<Material> Materials
        {
            get { return this.materials; }
            set { this.materials = value; }
        }

        private ICollection<Homework> homeworks;
        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public Course()
        {
            this.homeworks = new HashSet<Homework>();
            this.materials = new HashSet<Material>();
            this.students = new HashSet<Student>();
        }
    }
}
