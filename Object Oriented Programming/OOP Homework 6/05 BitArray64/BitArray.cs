using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BitArray64
{
    class BitArray
    {
        static void Main()
        {
            Console.WriteLine("Task 05 - Implementing BitArray64 value type\r\n");

            BitArray64 arr1 = new BitArray64();
            BitArray64 arr2 = new BitArray64();
            bool val = false;
            int idx = 0;

            foreach (var item in arr1)
            {
                // some stupid operations but only to check that foreach works !!! 
                arr1[idx] = val;
                arr2[idx++] = val;
                val = !val;
            }
            Console.WriteLine("First  array: " + arr1);             
            Console.WriteLine("Second array: " + arr2);

            Console.WriteLine("Comparison arr1 == arr2 -> " + (arr1 == arr2));

            for (int i = 0; i < 64; i++)
            {
                arr1[i] = (i % 3 == 0); // each third bit is set to 1, others to 0
                arr2[i] = (i % 4 == 0); // each fourth bit is set to 1, others to 0
            }
            Console.WriteLine("\r\nFirst  array: " + arr1);
            Console.WriteLine("Second array: " + arr2);
            Console.WriteLine("Comparison arr1 != arr2 -> " + (arr1 != arr2));

            idx = 0;
            Console.WriteLine("\r\nChecking bit by bit:");
            foreach (var item in arr2)
            {
                Console.Write((idx++).ToString()+"-"+item + " ");
            }

            Console.WriteLine("\r\n\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
