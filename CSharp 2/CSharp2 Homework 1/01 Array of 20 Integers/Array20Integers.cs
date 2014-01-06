using System;

class Array20Integers
{
    static void Main()
    {
        Console.WriteLine("Task 01 - 20 Integers Array Building\n\n");
        int[] numbers = new int[20];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i * 5;
            Console.WriteLine("Array: numbers[{0,2}] = {1,2}", i, numbers[i]);
        }
        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}

