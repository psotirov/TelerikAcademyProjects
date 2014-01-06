using System;
using System.Collections.Generic;

namespace _02_IEnumerable_Extensions
{
    public static class IEnumerableExt
    { 
        // all extension methods use "dynamic" type in order to have maximal type compatibility
        // and return "null" on empty collection (if possible)
        // the returned type is the same as the input one
        public static T Sum<T>(this IEnumerable<T> enumCollection)
        {
            dynamic sum = null;
            foreach (T element in enumCollection)
            {
                if (sum == null) sum = element; // assignment of first element
                else sum = sum + element; // and doing required operation for the rest
            }
            return (T)sum;
        }

        public static T Product<T>(this IEnumerable<T> enumCollection)
        {
            dynamic product = null;
            foreach (T element in enumCollection)
            {
                if (product == null) product = element;
                else product = product * element;
            }
            return (T)product;
        }


        public static T Min<T>(this IEnumerable<T> enumCollection)
        {
            dynamic min = null;
            foreach (T element in enumCollection)
            {
                if (min == null || min.CompareTo(element) >= 0) min = element;
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> enumCollection)
        {
            dynamic max = null;
            foreach (T element in enumCollection)
            {
                if (max == null || max.CompareTo(element) <= 0) max = element;
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> enumCollection)
        {
            dynamic sum = 0;
            int count = 0;
            foreach (T element in enumCollection)
            {
                if (sum == null) sum = element;
                else sum = sum + element;
                count++;
            }
            return (T)(sum/count);
        }

        public static string ToString<T>(this IEnumerable<T> enumCollection) // extension method that formats the string output if IEnumerable<T> 
        {
            string result = "{ ";
            foreach (var item in enumCollection)
            {
                result += item + " ";
            }

            return result + "}";
        }


        static void Main()
        {
            Console.WriteLine("Task 02 - IEnumerable Extensions");
            int[] collection = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("\r\nCollection of ints: " + collection.ToString<int>());
            Console.WriteLine("Sum: " + collection.Sum<int>());
            Console.WriteLine("Product: " + collection.Product<int>());
            Console.WriteLine("Max: " + collection.Max<int>());
            Console.WriteLine("Min: " + collection.Min<int>());
            Console.WriteLine("Average: " + collection.Average<int>());

            string[] collection2 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Console.WriteLine("\r\nCollection of strings: " + collection2.ToString<string>());
            Console.WriteLine("Sum: " + collection2.Sum<string>());
            // This throws exeption: Console.WriteLine("Product: " + collection2.Product<string>()); 
            Console.WriteLine("Max: " + collection2.Max<string>());
            Console.WriteLine("Min: " + collection2.Min<string>());
            // This throws exeption also:  Console.WriteLine("Average: " + collection2.Average<string>());

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
