using System;
using System.Collections.Generic;

namespace _01_School
{
    public class Teacher:People
    {
        public List<Discipline> Disciplines;

        public Teacher(string name, Discipline discipline = null)
            : base(name)
        {
            this.Disciplines = new List<Discipline>();
            if (discipline != null) this.Disciplines.Add(discipline);
        }

        public override string ToString()
        {
            string result = "Teacher { Name:" + this.Name + ", List of teached Disciplines:\r\n";
            foreach (Discipline d in this.Disciplines)
	        {
                result += d.ToString() + ";\r\n";
            }
            return result + "}";
        }
    }
}
