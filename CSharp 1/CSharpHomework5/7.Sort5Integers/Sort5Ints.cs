using System;

class Sort5Integers
{
    static void Main()
    {
        int n = 5;
        string input;
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {       
            Console.Write("Please enter {0} integer: ", i+1);
            input = Console.ReadLine();
            if (!int.TryParse(input, out numbers[i])) return;
        }

        //Bubblesort method
        for (int i = 1; i < n; i++)
            for (int j = 0; j < (n-i); j++)
                if (numbers[j] > numbers[j+1])
                {
                    int temp = numbers[j+1];
                    numbers[j + 1] = numbers[j];
                    numbers[j] = temp;
                }
        
        Console.WriteLine("The sorted list of integers is:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Integer [{0}] = {1}", i + 1, numbers[i]);
        } 
    }
}

