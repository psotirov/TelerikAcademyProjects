using System;
using System.Collections.Generic;
using System.IO;

namespace Salaries
{
    /// <summary>
    /// Algo academy - February 2013 - Salaries - BGCoder 100/100
    /// </summary>
    class Salaries
    {
        const int SingleSalary = 1;
        static int employeesCount;
        static ulong[] salaries;
        static List<int>[] employees;

        static void Main()
        {
            //Console.SetIn(new StreamReader(@"..\..\input.txt"));
            GetInput();

            ulong totalSalaries = 0;
            for (int i = 0; i < employeesCount; i++)
            {
                totalSalaries += GetSalary(i);
            }

            Console.WriteLine(totalSalaries);
        }

        static ulong GetSalary(int employee)
        {
            if (salaries[employee] > 0)
            {
                return salaries[employee];
            }

            ulong salary = 0;
            foreach (var inferior in employees[employee])
            {
                salary += GetSalary(inferior);
            }

            // memoization
            salaries[employee] = salary;
            return salary;
        }

        static void GetInput()
        {
            employeesCount = int.Parse(Console.ReadLine());
            employees = new List<int>[employeesCount];
            salaries = new ulong[employeesCount];
            for (int i = 0; i < employeesCount; i++)
            {
                employees[i] = new List<int>();
                string dataLine = Console.ReadLine().Trim();
                for (int chief = 0; chief < employeesCount; chief++)
                {
                    if (dataLine[chief] == 'Y')
                    {
                        employees[i].Add(chief);
                    }
                }

                // if the employee does not have inferiors, its salary is SingleSalary (1)
                if (employees[i].Count == 0)
                {
                    salaries[i] = SingleSalary;
                }
            }
        }
    }
}
