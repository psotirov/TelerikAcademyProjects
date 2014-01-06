using System;

namespace _01_School
{
    public class Discipline
    {
        public string Name { get; set; }
        public int LecturesCount { get; set; }
        public int ExcercisesCount { get; set; }
        public string Comment { get; set; }

        public Discipline(string name, int lectures=1, int excercises = 1) // must have name and at least 1 lecture and 1 excersise
        {
            this.Name = name;
            this.LecturesCount = lectures;
            this.ExcercisesCount = excercises;
        }

        public override string ToString()
        {
            return "Discipline { Name:" + this.Name + ", Lectures: " + this.LecturesCount + ", Excercises: " + this.ExcercisesCount + "}";
        }
    }
}
