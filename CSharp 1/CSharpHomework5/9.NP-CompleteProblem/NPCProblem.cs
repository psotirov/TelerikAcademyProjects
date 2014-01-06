using System;

class NPCProblem
{
    static void Main()
    {
        Console.Write("Please enter number of integers to solve NP-Complete problem [2, 31]: ");
        string input = Console.ReadLine();
        int n = 0;
        if (!int.TryParse(input, out n) || (n < 2) || (n > 31)) return;
        int totalComb = (1 << n) - 1; //nuber of total combinations is 2^n-1
        Console.WriteLine("Number of total combinations is " + totalComb);
        int[] numbers = new int[n];
        int totalSums = 0;
        for (int i = 0; i < n; i++) // requests numbers input
        {
            do
            {                
                Console.Write("Please enter {0} integer: ", i + 1);
                input = Console.ReadLine();
            } while (!int.TryParse(input, out numbers[i])); // endless loop until user enters correct number (entering a lot of numbers causes mistakes in most cases) 
        }

        for (int i = 1; i <= totalComb; i++) // Main loop representing all combination of numbers (except empty subset)
        {
            int sum = 0;
            string numbersList = "\n\nCombination "+ i + "\n\n";
            for (int j = 0; j < n; j++) // numbers selection loop - in the number "i" each bit position that is set to 1 represents the index of the participating number from the array 
                if (((i >> j) & 1) == 1)
                {
                    sum += numbers[j];
                    numbersList = numbersList + string.Format("N[{0}] = {1}\n",j+1 ,numbers[j]);
                }

            if (sum == 0)
            {
                Console.WriteLine(numbersList);
                totalSums++;
            }
        }
        Console.WriteLine("Total number of 0 sums: "  + totalSums);
    }
}

