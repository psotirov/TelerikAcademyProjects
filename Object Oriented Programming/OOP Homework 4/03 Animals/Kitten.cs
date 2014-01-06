using System;

namespace _03_Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age = 0)
            : base(name, age, false)
        {
        }

        public override string Say()
        {
            return "Kitten - Soft Myau";
        }

        public override string ToString()
        {
            return String.Format("Kitten - Name: {0}, Age: {1}, Sex: {2}", this.Name, this.Age, (IsMale) ? "Male" : "Female");
        }
    }
}
