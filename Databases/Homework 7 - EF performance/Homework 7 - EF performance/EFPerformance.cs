using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_7___EF_performance
{
    class EFPerformance
    {
        static void Main()
        {
            // Task 1
            ShowEmployeesNameDepartmentTown_Slow(); // 340 SQL queries
            ShowEmployeesNameDepartmentTown_Fast(); // 1 SQL query

            // Task 2
            ShowEmployeesFromTown_Slow("Sofia"); // 66 SQL queries
            ShowEmployeesFromTown_Fast("Sofia"); // 2(+1) SQL queries 
        }

        static void ShowEmployeesNameDepartmentTown_Slow()
        {
            Console.WriteLine("Slow selection of employees");
            using (var ctx = new TelerikAcademyEntities())
            {
                foreach (var employee in ctx.Employees)
                {
                    Console.WriteLine("Employee: {0}; Department: {1}; Town: {2}",
                        employee.FirstName + " " + employee.LastName, 
                        employee.Department.Name, employee.Address.Town.Name);
                }
            }
        }

        static void ShowEmployeesNameDepartmentTown_Fast()
        {
           Console.WriteLine("Fast selection of employees using INCLUDE");
            using (var ctx = new TelerikAcademyEntities())
            {
                foreach (var employee in ctx.Employees.Include("Department").Include("Address").Include("Address.Town"))
                {
                    Console.WriteLine("Employee: {0}; Department: {1}; Town: {2}",
                        employee.FirstName + " " + employee.LastName,
                        employee.Department.Name, employee.Address.Town.Name);
                }
            } 
        }

        static void ShowEmployeesFromTown_Slow(string town) 
        {
            Console.WriteLine("Slow selection of employees");
            using (var ctx = new TelerikAcademyEntities())
            {
                List<Address> addressesFromTown =
                    ctx.Addresses.ToList().    
                    Where(a => a.Town.Name == town).ToList();
                List<Employee> employeesFromTown =
                    addressesFromTown.SelectMany(a => a.Employees).ToList();
                foreach (var employee in employeesFromTown)
                {
                    Console.WriteLine("Employee: " + employee.FirstName + " " + employee.LastName);
                } 
            }
        }

        static void ShowEmployeesFromTown_Fast(string town) 
        {
            Console.WriteLine("Fast selection of employees reducing toList invokes");
            using (var ctx = new TelerikAcademyEntities())
            {
                List<Address> addressesFromTown =
                     ctx.Addresses.Where(a => a.Town.Name == town).ToList();
                List<Employee> employeesFromTown =
                    addressesFromTown.SelectMany(a => a.Employees).ToList();
                foreach (var employee in employeesFromTown)
                {
                    Console.WriteLine("Employee: " + employee.FirstName + " " + employee.LastName);
                } 
            }
        }
    }
}
