using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Humans
{
    class Humans
    {
        static void Main()
        {
            Console.WriteLine("Task 02 - Implement abstract Human and inherited Student and Worker");

            // Creates array of 10 students and sorts them by their Grade
            Student[] students = new Student[10];
            students[0] = new Student("Asen Kanibalov", 100);
            students[1] = new Student("Asen Magarov", 10);
            students[2] = new Student("Boian Magesnikov", 50);
            students[3] = new Student("Bata Zdravkovich", 5);
            students[4] = new Student("Cliff Richard", 85);
            students[5] = new Student("Katia Piskaleva", 12);
            students[6] = new Student("Manaf Manafov", 48);
            students[7] = new Student("Doktor Ohboliev", 77);
            students[8] = new Student("Asen Mangalov", 24);
            students[9] = new Student("Pesho Nabarov",97);
            IEnumerable<Student> sortedStud = students.OrderBy((hiks) => hiks.Grade);
            Console.WriteLine("\r\n\r\nStudents are:\r\n");
            foreach (var item in sortedStud)
            {
                Console.WriteLine(item);
            }

            // Creates array of 10 workers and sorts them in descending order by their earned money per hour
            Worker[] workers = new Worker[10];
            workers[0] = new Worker("Kanibal Asenov", 1000);
            workers[1] = new Worker("Magardich Asenov", 1110);
            workers[2] = new Worker("Magadance Boianov", 2500);
            workers[3] = new Worker("Zdravko Batovich", 1500);
            workers[4] = new Worker("Richard Cliff", 850);
            workers[5] = new Worker("QQ band", 50);
            workers[6] = new Worker("Manaf Manasian", 480);
            workers[7] = new Worker("Boli Doktorov", 770);
            workers[8] = new Worker("Mangal Asenov", 1240);
            workers[9] = new Worker("Nabarah Peshonisian", 970);
            Array.Sort<Worker>(workers, CompareByMoney); // using Array.Sort method with proper Comparison<T> delegate, see below 
            Console.WriteLine("\r\n\r\nWorkers are:\r\n");
            foreach (var item in workers)
            {
                Console.WriteLine(item);
            }

            // Concatenated both arrays in a new single one and sorts members by name 
            Human[] collect = new Human[20];
            Array.Copy(workers, collect, workers.Length);
            Array.Copy(students, 0, collect, workers.Length, students.Length);
            Array.Sort(collect);
            Console.WriteLine("\r\n\r\nBut all of them are Humans:\r\n");
            foreach (var item in collect)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\n\r\nPress Enter to finish");
            Console.ReadLine();
        }

        private static int CompareByMoney(Worker y, Worker x) //reversed order (sorts descending)  
        {
            if (x == null || y == null) //resolves marginal cases, i.e. null is less than value, but value is larger than null - depends on position
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                return 1;
            }
            return (int)(x.MoneyPerHour() - y.MoneyPerHour());
        }
    }
}
