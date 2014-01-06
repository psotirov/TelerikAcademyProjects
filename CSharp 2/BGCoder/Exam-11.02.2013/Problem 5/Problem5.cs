using System;

class Problem5
{
    static void Main()
    {
        // temporary console input redirection
        //Console.SetIn(new System.IO.StreamReader("test.001.in.txt"));

        // First task
        string[] line1 = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        bool hasWinner = false;
        int maxPoints = 0;
        int maxIndex = 0;
        for (int i = 0; i < line1.Length; i++)
        {
            int pointsI = int.Parse(line1[i]);
            if (pointsI == 21)
            {
                if (!hasWinner)
                {
                    hasWinner = true;
                    maxPoints = 21;
                    maxIndex = i;
                }
                else
                {
                    maxIndex = -1;
                    break;
                }
            }
 
            if (pointsI < 21)
            {
                if (pointsI > maxPoints)
                {
                    maxPoints = pointsI;
                    maxIndex = i;
                }
                else if (pointsI == maxPoints)
                {
                    maxIndex = -1;
                }
            }
        }
        Console.WriteLine(maxIndex);

        // Second Task
        string[] line2 = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] cakes = new int[line2.Length];
        for (int i = 0; i < line2.Length; i++)
        {
            cakes[i] = int.Parse(line2[i]);
        }
        Array.Sort(cakes);
 
        int friends = int.Parse(Console.ReadLine()) + 1;
        int pos = cakes.Length - 1;
        int bites = 0;
        while (pos >= 0)
        {
            bites += cakes[pos];
            pos -= friends;
        }
        Console.WriteLine(bites);
        
        // Third task
        string[] line3 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] coins = new int[6];
        for (int i = 0; i < line3.Length; i++)
        {
            coins[i] = int.Parse(line3[i]);
        }
        int exchanges = 0;
        int inputValue = coins[0] * 81 + coins[1] * 9 + coins[2]; // first checks if we have enough money for a beer
        int neededValue = coins[3] * 81 + coins[4] * 9 + coins[5]; // converts all to bronze 
        if (inputValue < neededValue)
        {
            Console.WriteLine("-1");
        }
        else
        {
            while (coins[0] < coins[3] || coins[1] < coins[4] || coins[2] < coins[5])
            {
                exchanges++;
                if (coins[0] < coins[3])
                {
                    if (coins[1] >= 11)
                    {
                        coins[1] -= 11;
                        coins[0]++;
                     }
                    else
                    {
                        coins[2] -= 11;
                        coins[1]++;
                    }
                } else if (coins[1] < coins[4])
                {
                    if (coins[2] >= 11)
                    {
                        coins[2] -= 11;
                        coins[1]++;
                    }
                    else
                    {
                        coins[0] -= 1;
                        coins[1] += 9;
                    }
                } else if (coins[2] < coins[5])
                {
                    if (coins[1] >= 1)
                    {
                        coins[1] -= 1;
                        coins[2] += 9;
                    }
                    else
                    {
                        coins[0] -= 1;
                        coins[1] += 9;
                    }
                }
            }
            Console.WriteLine(exchanges);
        }
        //Console.ReadLine();
    }
}
