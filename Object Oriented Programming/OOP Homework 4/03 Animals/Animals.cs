using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Animals
{
    class Animals
    {
        static void Main()
        {
            Frog[] frogs = new Frog[18];
            for (int i = 0; i < frogs.Length; i++)
            {
                frogs[i] = new Frog("Frogname " + (i + 1), i * 3 + 1, (i % 2 == 0) ? true : false); // male:female distribution 50/50
                Console.WriteLine(frogs[i] + " and says " + frogs[i].Say());
            }

            Dog[] dogs = new Dog[15];
            for (int i = 0; i < dogs.Length; i++)
            {
                dogs[i] = new Dog("Dogname " + (i + 1), i * 5 + 1, (i % 3 == 0) ? true : false); // male:female distribution 30/70
                Console.WriteLine(dogs[i] + " and says " + dogs[i].Say());
            }

            Kitten[] kittens = new Kitten[13];
            for (int i = 0; i < kittens.Length; i++)
            {
                kittens[i] = new Kitten("Kittenname " + (i + 1), i * 2 + 1); // all are female
                Console.WriteLine(kittens[i] + " and says " + kittens[i].Say());
            }
            Tomcat[] tomcats = new Tomcat[14];
            for (int i = 0; i < tomcats.Length; i++)
            {
                tomcats[i] = new Tomcat("Tomcatname " + (i + 1), i * 4 + 1); // all are male
                Console.WriteLine(tomcats[i] + " and says " + tomcats[i].Say());
            }

            // average age calculation for each kind of animal
            Console.WriteLine("Average frogs age: " + Animal.AverageAge(frogs));
            Console.WriteLine("Average dogs age: " + Animal.AverageAge(dogs));
            Console.WriteLine("Average kittens age: " + Animal.AverageAge(kittens));
            Console.WriteLine("Average tomcats age: " + Animal.AverageAge(tomcats));

            Console.WriteLine("\r\n\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
