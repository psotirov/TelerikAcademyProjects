using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Divisible_Numbers
{    
    static class NumbersDiv7And3
    {
        static void Print(this IEnumerable<int> arr) // helper extension method to print the query result on the Console 
        {
            Console.Write("Result = { ");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
        }

        static void Main()
        {
            Console.WriteLine("Task 06 - Find in an array of integers all numbers divisible by 7 and 3\r\n");

            int[] numbers = new int[100]; // creates an array that holds the numbers between 1 and 100
            for (int i = 0; i < 100; i++)
            {
                numbers[i] = i+1;
            }
            Console.WriteLine("We have an array of integer numbers with values between 1 and 100");

            // Built-in extension method and lambda expression solution
            var result = numbers.Where(num => (num % 7 == 0) && (num % 3 == 0));
            Console.WriteLine("\r\nBuilt-in extension method and lambda expression:");
            result.Print();

            // LINQ solution
            result =
                from num in numbers
                where (num % 7 == 0) && (num % 3 == 0)
                select num;
            Console.WriteLine("\r\nLINQ:");
            result.Print();

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
