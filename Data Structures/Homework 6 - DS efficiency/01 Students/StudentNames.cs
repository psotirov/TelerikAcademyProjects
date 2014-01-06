using System;

namespace _01_Students
{
    public class StudentNames
    {
        public string Name { get; set; }
        public string Family { get; set; }

        public StudentNames(string name, string family)
        {
            this.Name = name;
            this.Family = family;
        }

        public override string ToString()
        {
            return this.Family + " " + this.Name;
        }
    }
}
