using System;

namespace _03_Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age = 0)
            : base(name, age, true)
        {
        }

        public override string Say()
        {
            return "Tomcat - Deep Myau";
        }

        public override string ToString()
        {
            return String.Format("Tomcat - Name: {0}, Age: {1}, Sex: {2}", this.Name, this.Age, (IsMale) ? "Male" : "Female");
        }
    }
}
