using System;

class SafelyCompareReals
{
    static void Main()
    {
        decimal FirstNumber = 0;
        decimal SecondNumber = 0;
        Console.Write("Please enter first real number: ");
        string Line = Console.ReadLine();

        if (Decimal.TryParse(Line, out FirstNumber))
	    {
		    Console.Write("Please enter second real number: ");
            Line = Console.ReadLine();
            if (Decimal.TryParse(Line, out SecondNumber))
            {
                bool Result = (Math.Abs(FirstNumber - SecondNumber) <= 0.000001m);
                Console.WriteLine("The Numbers are equal? " + Result);
                return;
            }
 	    }
        Console.WriteLine("Wrong Number(s)!");

    }
}

