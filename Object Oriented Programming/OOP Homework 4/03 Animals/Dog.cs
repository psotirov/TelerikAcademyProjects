using System;

namespace _03_Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age = 0, bool isMale = true)
            : base(name, age, isMale)
        {
        }

        public override string Say()
        {
            return "Dog - Bau, Bau";
        }

        public override string ToString()
        {
            return String.Format("Dog - Name: {0}, Age: {1}, Sex: {2}", this.Name, this.Age, (IsMale)?"Male":"Female");
        }
    }
}
