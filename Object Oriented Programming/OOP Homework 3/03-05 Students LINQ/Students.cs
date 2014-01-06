using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_05_Students_LINQ
{
    // DISCLAIMER: even the good practice is to put each class/structure in a separate file
    // here we are using a single file due to the task simplicity
    struct Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Students(string fn, string ln, int a):this() // constructor that fills all data
        {
            this.FirstName = fn;
            this.LastName = ln;
            this.Age = a;
        }

        public override string ToString() // used to show the structure
        {
            return String.Format("{{{0} {1}-{2}}}", this.FirstName, this.LastName, this.Age);
        }
    }

    static class StudentsLINQ
    {
        public static void Print<T>(this IEnumerable<T> struc) // helper extension method to print on console the quiery result
        {
            foreach (var item in struc)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Students[] dbData = new Students[] {
                new Students("Pesho","Goshov",23),
                new Students("Gosho","Peshov",32),
                new Students("Tosho","Toshev",43),
                new Students("Mincho","Praznikov",19),
                new Students("Praznik","Minchev",75),
                new Students("Zanzibar","Makaronev",21),
            };

            Console.WriteLine("Tasks 03 to 05 - LINQ Operations over data");
            Console.WriteLine("\r\nInitial Data:");
            dbData.Print<Students>();

            Console.WriteLine("\r\n03-Finds all students whose last name is after the first name alphabetically");
            var result =
                from stud in dbData
                where stud.FirstName.CompareTo(stud.LastName) < 0
                select stud;
            result.Print<Students>();

            Console.WriteLine("\r\n04-Selects students that have age between 18 and 24 years");
            result =
                from stud in dbData
                where stud.Age > 18 && stud.Age < 24
                select stud;
            result.Print<Students>();

            Console.WriteLine("\r\n05-Sorts students by first and last name in decending order");
            result =
                from stud in dbData
                orderby stud.FirstName descending, stud.LastName descending
                select stud;
            result.Print<Students>(); // here alternatively we can show only students names with foreach

            Console.WriteLine("\r\nThe same but using built-in extension methods and lambda expressions"); 
            result = dbData.OrderByDescending( x => x.FirstName).ThenByDescending( x => x.LastName);
            result.Print<Students>(); 

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
