using System;

namespace _01_School
{
    public class People
    {
        public string Name { get; set; }
        public string Comment { get; set; }

        public People(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return "Name: " + this.Name;
        }
    }
}
