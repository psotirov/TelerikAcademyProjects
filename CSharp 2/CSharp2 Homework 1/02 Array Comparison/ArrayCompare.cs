using System;

class ArrayCompare
{
    static void Main()
    {
        Console.WriteLine("Task 02 - Array Comparison\n\n");
        Console.Write("Please enter length of both arrays [2,100]:");
        int len = 0;
        if (!int.TryParse(Console.ReadLine(), out len) || len < 2 || len > 100)
        {
            Console.WriteLine("Wrong array length");
            return;
        }

        int[] arrayA = new int[len];
        int[] arrayB = new int[len];

        Console.WriteLine("Please enter integer values of first array\n");
        for (int i = 0; i < len; i++)
        {
            Console.Write("ArrayA[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out arrayA[i]))
            {
                Console.WriteLine("Wrong array number");
                return;
            }
        }

        Console.WriteLine("Please enter integer values of second array\n");
        for (int i = 0; i < len; i++)
        {
            Console.Write("ArrayB[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out arrayB[i]))
            {
                Console.WriteLine("Wrong array number");
                return;
            }
        }
            
        Console.WriteLine("Result of comparison\n");
        for (int i = 0; i < len; i++)
		{
			Console.WriteLine("ArrayA[{0}] == ArrayB[{0}]? -> {1}",i, (arrayA[i]==arrayB[i]));
		}

        Console.Write("\nPress Enter to finish");
        Console.ReadLine();
    }
}
