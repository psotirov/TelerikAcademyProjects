using System;

namespace _04_Person
{
    class Persons
    {
        static void Main()
        {
            Console.WriteLine("Task 04 - Person\r\n");

            Person person1 = new Person("Pesho Peshov");
            Person person2 = new Person("Gosho Goshov", 25);
            Person person3 = new Person("Bai Dragan", 99);

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine(person3);

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
