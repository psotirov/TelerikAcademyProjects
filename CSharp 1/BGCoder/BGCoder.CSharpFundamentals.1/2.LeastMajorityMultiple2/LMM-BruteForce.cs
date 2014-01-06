using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] numbers = new int[5];
        int i;
        for (i = 0; i < 5; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);
        int LMM;
        int count = 0;
        for (LMM=numbers[2]; count < 3; LMM++)
            for (i = 0, count = 0; i < 5 && count < 3; i++)
                if (LMM % numbers[i] == 0) count++;
        Console.WriteLine(LMM-1);
    }
}