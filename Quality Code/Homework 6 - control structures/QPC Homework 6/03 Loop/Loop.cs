using System;

namespace _03_Loop
{
    class Loop
    {
        static void Main(string[] args)
        {
            int[] array = new int[100];
            int expectedValue = 50;
            bool isFound = false;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(array[i]);
                if (i % 10 == 0 && array[i] == expectedValue)
                {
                    isFound = true;
                    break; // when i=666 (or 667) it is greater than 100, so we must exit
                }                
            }

            // some code here
            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
