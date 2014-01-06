using System;

namespace _04_Person
{
    public class Person
    {
        public string Name { get; set; }
        private int age;
        public object Age
        {
            get // boxing age
            {
                if (age > 0) return this.age;
                else return null;
            }
            set // unboxing age
            {
                if (value == null || (int)value < 0) this.age = 0;
                else this.age = (int)value;
            }
        }

        public Person(string name, object age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return String.Format("Person {{ Name= {0}, Age= {1} }}", this.Name, (this.Age == null)?"Unspecified":this.Age.ToString());
        }
    }
}
