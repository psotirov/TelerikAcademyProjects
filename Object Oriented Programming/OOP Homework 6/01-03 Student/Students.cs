using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_03_Student
{
    class Students
    {
        static void Main()
        {
            Console.WriteLine("Tasks 01 to 03 - Implementing Student class");

            Student student1 = new Student("Pesho Peshov Peshistia", 123456789); // sets student1 names and SSN
            student1.Specialty = Specialties.SoftwareEngineering; // sets Specialty, Faculty and University
            student1.Address = "Sofia, Kriva Bara 17"; // sets address
            student1.EMail = "pesho@abv.co.uk"; // sets e-mail
            student1.Phone = "+359 878 878 878"; // sets phone
            Console.WriteLine("\r\n" + student1);

            Student student2 = new Student("Gosho Goshov Goshistia", 987654321); // the same to student2
            student2.Specialty = Specialties.UrbanPlanning;
            student2.Address = "Sofia, Prava Reka 171"; // sets address
            student2.EMail = "gosho@abv.ru"; // sets e-mail
            student2.Phone = "+359 898 898 898"; // sets phone
            Console.WriteLine("\r\n" + student2);

            Student student3 = (Student)student2.Clone(); // student2 is also a student 3 in other University
            student3.University = Universities.SU;
            student3.Faculty = Faculties.FMI;
            student3.Specialty = Specialties.Mathematics;
            Console.WriteLine("\r\nLast Student has Cloned and Specialty changed\r\n\r\n" + student3);

            Console.WriteLine("\r\nAre last two students equal? - " + (student2 == student3));

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
