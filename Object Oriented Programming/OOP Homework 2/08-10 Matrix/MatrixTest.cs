using System;

namespace _08_10_Matrix
{
    class MatrixTest
    {
        static void Main()
        {
            Console.WriteLine("Generic Matrix class implementation\n\n");

            Matrix<int> first = new Matrix<int>(5, 6); // empty matrix 5 x 6
            Console.WriteLine("First Matrix (empty):\n\n" + first);

            for (int r = 0; r < 5; r++)
                for (int c = 0; c < 6; c++)
                {
                    first[r, c] = r * 6 + c; // fill with consecutive numbers        
                }

            Console.WriteLine("Filled wit consecutive numbers:\n\n" + first);

            Matrix<int> second = new Matrix<int>(5, 6, 2); // matrix 5 x 6, filled with value 2
            Console.WriteLine("Second Matrix:\n\n" + second);
            Console.WriteLine("Result of First + Second:\n\n" + (first + second)); // sum

            Console.WriteLine("Result of First - Second:\n\n" + (first - second)); // subtract
            Matrix<int> third = new Matrix<int>(6, 8, 3);
            Console.WriteLine("Third Matrix:\n\n" + third); // matrix 6 x 8, filled with vaue 3
            Console.WriteLine("Result of First * Third:\n\n" + (first * third)); // multiply matrices 5x6 * 6x8 = 5x8
            // Console.WriteLine("Result of First * First:\n\n" + (first * first)); // multiply matrices 5x6 * 5x6 = exception

            if (third) Console.WriteLine("Third Matrix is not empty after checking with 'true' operator:\n\n");

            Console.WriteLine("\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
