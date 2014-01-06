using System;

/// <summary>
/// Task 2 - Colored Rabbits - BGCoder 100/100 
/// </summary>
class ColoredRabbits
{
    static void Main()
    {
        int countInterviewed = int.Parse(Console.ReadLine());
        int[] rabbitAnswers = new int[countInterviewed];
        for (int i = 0; i < countInterviewed; i++)
        {
            // each rabbit don't count itself, so we must add 1 more rabbit to the group
            rabbitAnswers[i] = int.Parse(Console.ReadLine()) + 1;
        }

        // sort answers so we can group equal answers
        Array.Sort(rabbitAnswers);

        // for each answer (n) greater than 1, we can assume that other not more than (n-1) equal answers are from the same color group
        // i.e. if we have {3, 3, 3} that means - each of those 3 equal colored rabbits answers for the others
        // but the same applies to {3, 3}, since it could be possible that some of the participating rabbits are not interviewed
        // i.e. we can skip the rest (n-1) answers

        int minimalCountRabbits = 0;
        for (int i = 0; i < countInterviewed; i++)
        {
            if (rabbitAnswers[i] > 1 && // we have more than one equal colored rabbits (said n)
                Array.LastIndexOf(rabbitAnswers, rabbitAnswers[i]) > i) // andwe have more than 1 ( to n-1) same answers 
            {
                // skip the rest (n-1) of them
                int j = 1;
                while ((i + j) < countInterviewed && rabbitAnswers[i + j] == rabbitAnswers[i] && j < rabbitAnswers[i])
                {
                    rabbitAnswers[i + j++] = 0;
                }                
            }

            // count rabbits
            minimalCountRabbits += rabbitAnswers[i];
        }

        Console.WriteLine(minimalCountRabbits);
    }
}