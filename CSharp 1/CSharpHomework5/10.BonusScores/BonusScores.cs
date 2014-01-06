using System;

class NPCProblem
{
    static void Main()
    {
        Console.Write("Please enter digit [1, 9]: ");
        string input = Console.ReadLine();
        int n = 0;
        if (!int.TryParse(input, out n)) return;
        switch (n)
        {
            case 1:
            case 2:
            case 3:
                n *= 10;
                break;
            case 4:
            case 5:
            case 6:
                n *= 100;
                break;
            case 7:
            case 8:
            case 9:
                n *= 1000;
                break;
            default:
                n = 0;
                break;
        }

        if (n > 0) Console.WriteLine("The new score: " + n);
        else Console.WriteLine("Wrong input!");
    }
}

