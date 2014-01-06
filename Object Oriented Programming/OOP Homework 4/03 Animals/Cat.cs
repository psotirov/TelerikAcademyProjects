using System;

namespace _03_Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age = 0, bool isMale = true)
            : base(name, age, isMale)
        {
        }

        public override string Say()
        {
            return "Cat - Myau";
        }

        public override string ToString()
        {
            return String.Format("Cat - Name: {0}, Age: {1}, Sex: {2}", this.Name, this.Age, (IsMale)?"Male":"Female");
        }
    }
}
