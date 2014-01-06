using System;

namespace _03_Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age = 0, bool isMale = true)
            : base(name, age, isMale)
        {
        }

        public override string Say()
        {
            return "Frog - Quack, Quack";
        }

        public override string ToString()
        {
            return String.Format("Frog - Name: {0}, Age: {1}, Sex: {2}", this.Name, this.Age, (IsMale)?"Male":"Female");
        }
    }
}
