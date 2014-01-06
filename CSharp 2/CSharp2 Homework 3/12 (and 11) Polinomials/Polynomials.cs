using System;

class Polynomials
{
    static void Main()
    {
        Console.WriteLine("Task 12 (and 11 included) - Operations with polynomials\n\nThe polynomial An*x^n + An-1*x^(n-1) + .. + A1*x + A0"+
                            " is presented as\narray A[0] = A0, A[1] = A1, ..... , A[N] = An\n");

        int dimA = 0;
        Console.Write("Please enter first polynomial max power N [2, 100]: ");
        if (!int.TryParse(Console.ReadLine(), out dimA) || dimA < 2 || dimA > 100) // wrong array dimension
        {
            Console.WriteLine("Not a valid array dimension");
            return;
        }

        int[] coefA = new int[dimA];
        for (int i = 0; i < dimA; i++)
        {
            Console.Write("Please enter A[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out coefA[i])) // wrong integer
            {
                Console.WriteLine("Not a valid integer");
                i--;
            }
        }

        int dimB = 0;
        Console.Write("Please enter first polynomial max power N [2, 100]: ");
        if (!int.TryParse(Console.ReadLine(), out dimB) || dimB < 2 || dimB > 100) // wrong array dimension
        {
            Console.WriteLine("Not a valid array dimension");
            return;
        }

        int[] coefB = new int[dimB];
        for (int i = 0; i < dimB; i++)
        {
            Console.Write("Please enter B[{0}] = ", i);
            if (!int.TryParse(Console.ReadLine(), out coefB[i])) // wrong integer
            {
                Console.WriteLine("Not a valid integer");
                i--;
            }
        }

        int choice = 0;
        do
        {
            Console.Write("\n\n\nPolynomial A = ");
            PrintResult(coefA);
            Console.Write("\nPolynomial B = ");
            PrintResult(coefB);

            Console.Write("\nPlease enter operation:\n0 - Exit\n1 - Add\n2 - Subtract\n3 - Multiply\n");
            int.TryParse(Console.ReadLine(), out choice);
            if (choice > 0 && choice < 4) Console.Write("\nResult = ");

            switch (choice)
            {
                case 1:  PrintResult(PolySum(coefA, coefB)); break;
                case 2:  PrintResult(PolySub(coefA, coefB)); break;
                case 3:  PrintResult(PolyMul(coefA, coefB)); break;
                default: break;
            }
            
        } while (choice > 0);
    }

    static void PrintResult(int[] result)
    {
        bool isFirst = true;
        for (int i = result.Length - 1; i >= 0; i--)
        {
            int coef = result[i]; // takes current coefficient
            if (coef != 0 || (isFirst && i==0)) // zero coef are not shown (except first coef when there is no any other coefs)
            {
                if (!isFirst)
                {
                    if (coef < 0)
                    {
                        Console.Write(" - ");
                        coef = -coef; // coef = |coef|
                    }
                    else Console.Write(" + ");
                }
                isFirst = false;
                if (i == 0) Console.Write(coef); // last element - only coef
                else if (i == 1) Console.Write("{0}*x", coef); // pre-last element - only coef*x
                else Console.Write("{0}*x^{1}", coef, i); // otherwise - coef*x^i
            }
        }
        Console.WriteLine();
    }

    static int[] PolySum(int[] cA, int[] cB)
    {
        int[] result = new int[(cA.Length > cB.Length) ? cA.Length:cB.Length];
        // creates new array with index, equal to the largest index of arguments arrays

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = ((i >= cA.Length) ? 0 : cA[i]) + ((i >= cB.Length) ? 0 : cB[i]); //sums equal position coefficients
        }
        return result;
    }

    static int[] PolySub(int[] cA, int[] cB)
    {
        int[] result = new int[(cA.Length > cB.Length) ? cA.Length : cB.Length];
        // creates new array with index, equal to the largest index of arguments arrays

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = ((i >= cA.Length) ? 0 : cA[i]) - ((i >= cB.Length) ? 0 : cB[i]); //sums equal position coefficients
        }
        return result;
    }

    static int[] PolyMul(int[] cA, int[] cB)
    {
        int[] result = new int[cA.Length + cB.Length - 1];
        // creates new array with index, equal to the sum of both indices of arguments arrays

        for (int a = 0; a < cA.Length; a++)
            for (int b = 0; b < cB.Length; b++)
            {
                result[a+b] += cA[a]*cB[b]; //multiply each to other position coefficients and sums to equal powers
            }
        return result;
    }
}
