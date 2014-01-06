using System;

namespace _03_Animals
{
    public abstract class Animal : ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }

        public Animal(string name, int age = 0, bool isMale = true)
        {
            this.Name = name;
            this.Age = age; // just born by default
            this.IsMale = isMale; // male animal by default
        }

        public abstract string Say(); // Say will be implemented for each kind of animal separately

        public static double AverageAge(Animal[] animals)
        {
            int sum = 0;
            for (int i = 0; i < animals.Length; i++)
            {
                sum += animals[i].Age;
            }
            return (double)sum / animals.Length;
        }
    }
}
