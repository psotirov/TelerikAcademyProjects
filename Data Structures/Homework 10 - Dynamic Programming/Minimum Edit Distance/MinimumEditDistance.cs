using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimum_Edit_Distance
{
    class MinimumEditDistance
    {
        const double ReplaceCost = 1.0;
        const double DeleteCost = 0.9;
        const double InsertCost = 0.8;

        static void Main()
        {
            Console.WriteLine("Minimal edit distance\n\n");
            string[,] data = new string[,] {
                { "developer", "enveloped", "(1 delete, 1 insert, 1 replace)" },    
                { "display", "player", "(3 delete, 2 insert)" },    
                { "kitten", "sitting", "(2 replace, 1 insert)" },    
            };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                Console.WriteLine("{0} -> {1} = {3:N1} {2}", data[i, 0], data[i, 1], data[i, 2],
                    LevenshteinDistance(data[i, 0], data[i, 1]));
            }
        }

        static double LevenshteinDistance(string firstWord, string secondWord)
        {
            // Selected "Iterative with two matrix rows" Levenshtein distance algorithm
            // http://en.wikipedia.org/wiki/Levenshtein_distance

            // degenerate cases
            if (firstWord == secondWord)
            {
                return 0.0; // no modification on equal strings
            }

            if (firstWord.Length == 0)
            {
                return secondWord.Length * InsertCost; // inserting each character into empty string 
            }

            if (secondWord.Length == 0)
            {
                return firstWord.Length * InsertCost; // inserting each character into empty string
            }

            // create two work vectors of distances
            double[] previousRow = new double[secondWord.Length + 1];
            double[] currentRow = new double[secondWord.Length + 1];

            // initialize the previous row of distances
            // this row is Matrix[0][i]: edit distance for an empty second word
            // the distance is the number of characters to insert to second word
            for (int i = 0; i < previousRow.Length; i++)
            {
                previousRow[i] = i * InsertCost;
            }

            for (int i = 0; i < firstWord.Length; i++)
            {
                // calculate current row distances from the previous row

                // first element of currentRow is Matrix[i+1][0]
                // edit distance is delete (i+1) chars from second word to match empty first word
                currentRow[0] = (i + 1) * DeleteCost;

                // use formula to fill in the rest of the row
                for (int j = 0; j < secondWord.Length; j++)
                {
                    double cost = (firstWord[i] == secondWord[j]) ? 0.0 : ReplaceCost;
                    currentRow[j + 1] = Math.Min(
                        Math.Min(previousRow[j + 1] + DeleteCost, currentRow[j] + InsertCost),
                        previousRow[j] + cost);
                }

                // copy current row to previous row for next iteration
                Array.Copy(currentRow, previousRow, currentRow.Length);
            }

            return currentRow[secondWord.Length];
        }
    }
}
