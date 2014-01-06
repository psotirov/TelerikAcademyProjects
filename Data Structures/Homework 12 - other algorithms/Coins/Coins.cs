using System;

namespace Coins
{
    class Coins
    {
        static void Main()
        {
            Console.WriteLine("Finds number of coins that equals to given sum\n\n");

            // int[] coins = new int[] { 1, 2, 5, 10, 20, 50 };
            int[] coins = new int[] { 1, 2, 5 };
            int[] count = new int[coins.Length];
            Console.WriteLine("Coins: {{ {0} }}\n", string.Join(", ", coins));
            Console.Write("Please enter the sum: ");
            int sum = 0;
            if (!int.TryParse(Console.ReadLine(), out sum) || sum < 1)
            {
                Console.WriteLine("Sum should be integer and greater than zero");
                return;
            }

            // using Greedy algorithm - use each coin as much as possible and use greater first
            Array.Sort(coins, (a,b) => (b - a));
            int partial = 0;
            for (int i = 0; i < coins.Length; i++)
			{
                while (partial+coins[i] <= sum)
                {
                    partial += coins[i];
                    count[i]++;
                }
            }

            for (int i = 0; i < coins.Length; i++)
            {
                Console.WriteLine("{0} pieces of coin {1} = {2}", count[i], coins[i], count[i] * coins[i]);
            }
        }
    }
}
