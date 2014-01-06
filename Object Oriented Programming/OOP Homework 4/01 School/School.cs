using System;
using System.Collections.Generic;

namespace _01_School
{
    class School
    {
        static void Main()
        {
            Console.WriteLine("Task 1 - School OOP Representation");

            List<SchoolClass> School = new List<SchoolClass>();
            School.Add(new SchoolClass("Class 1", new Teacher("Teacher 1", new Discipline("Discipline 1", 5)), new Student("Student 1", 1)));
            School.Add(new SchoolClass("Class 2", new Teacher("Teacher 2", new Discipline("Discipline 2", 6)), new Student("Student 2", 2)));
            School.Add(new SchoolClass("Class 3", new Teacher("Teacher 3", new Discipline("Discipline 3", 4)), new Student("Student 3", 3)));
            School.Add(new SchoolClass("Class 4", new Teacher("Teacher 4", new Discipline("Discipline 4", 5)), new Student("Student 4", 4)));
            School.Add(new SchoolClass("Class 5", new Teacher("Teacher 5", new Discipline("Discipline 5", 6)), new Student("Student 5", 5)));

            for (int c = 0; c < 5; c++) // iterates through classes
            {
                for (int t = 1; t < 4; t++) // iterates through teachers
                {
                    // adds a teacher
                    School[c].Teachers.Add(new Teacher("Teacher " + c*10+t+6, new Discipline("Discipline" + c*10+t+5 +"1", 6, 3)));
                    for (int d = 0; d < 4; d++)
                    {
                        // adds a discipline                        
                        School[c].Teachers[t].Disciplines.Add(new Discipline("Discipline "+ (c*10+t+5)*10 + d + 1, d + 2, 3));
                    }
                }
                for (int s = 1; s < 14; s++) // iterates through students
                {
                    // adds a student
                    School[c].Students.Add(new Student("Student "+s+5,s+5));
                }
            }

            foreach (SchoolClass sc in School)
            {
                Console.WriteLine(sc);
            }

            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
