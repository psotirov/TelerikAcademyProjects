using System;

class SomeTasks
{
    static void Main()
    {
        Console.WriteLine("Task 12 - Various operations");

        int choice = 0;
        while (true)
        {
            Console.WriteLine("\nPlease select task:\n   0 - Exit\n   1 - Reverse number digits\n"+
                              "   2 - Average of integer numbers sequence\n   3 - Solve equation A*x + B = 0");
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 0: return;
                case 1: ReverseDigits(); break;
                case 2: AverageOfArray(); break;
                case 3: SolveEquation(); break;
                default: break;
            }
        }
    }

    static void ReverseDigits()
    {
        int numb = 0;
        Console.Write("\n\nPlease enter a number: ");
        if (int.TryParse(Console.ReadLine(), out numb) && numb > 0) // correct integer was entered
        {
            int result = 0;
            while (numb != 0)
            {
                result *= 10; // shifts one digit to the left 
                result += numb % 10; // adds the last digit of num 
                numb /= 10; // shifts one digit to the right
            }
            Console.WriteLine("The reversed number is {0}\n", result);
        }
        else
        {
            Console.WriteLine("Not a valid integer\n");
        }
    }

    static void AverageOfArray()
    {
        int dimN = 0;
        Console.Write("Please enter sequence of integers (divided with spaces): ");
        string[] nums = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries); 
        if (nums.Length < 1) // wrong array dimension
        {
            Console.WriteLine("Not a valid array dimension");
            return;
        }

        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int numb = 0;
            if (!int.TryParse(nums[i], out numb)) // wrong integer
            {
                Console.WriteLine("Not a valid integer");
                return;
            }
            sum += numb;
        }
        Console.WriteLine("\nThe average of array numbers is {0}.\n", sum/(double)nums.Length);
    }

    static void SolveEquation()
    {
        double coefA = 0;
        Console.Write("Please enter coef A: ");
        if (!double.TryParse(Console.ReadLine(), out coefA) || coefA == 0) // wrong coef A
        {
            Console.WriteLine("Not a valid coef A");
            return;
        }

        double coefB = 0;
        Console.Write("Please enter coef B: ");
        if (!double.TryParse(Console.ReadLine(), out coefB)) // wrong coef B
        {
            Console.WriteLine("Not a valid coef B");
            return;
        }

        Console.WriteLine("Result - X = {0}\n", -coefB/coefA);
    }
}

