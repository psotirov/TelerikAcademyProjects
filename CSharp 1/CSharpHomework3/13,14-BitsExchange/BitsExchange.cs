using System;

class BitsExchange
{
    static void Main()
    {
        Console.Write("Enter 32-bit unsigned integer: ");
        string input = Console.ReadLine();
        uint number = 0;
        if (!uint.TryParse(input, out number)) return;

        Console.WriteLine("Its binary representation is:");
        Console.WriteLine("33222222222211111111110000000000");
        Console.WriteLine("10987654321098765432109876543210");
        Console.WriteLine("--------------------------------");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));

        Console.Write("\nEnter quantity of bits to exchange (k, between 1 and 31): ");
        input = Console.ReadLine();
        int k = 0;
        if (!int.TryParse(input, out k) || (k <= 0) || (k > 31)) return;

        Console.Write("Enter first start position (p, between {0} and 31): ", k - 1);
        input = Console.ReadLine();
        int p = 0;
        if (!int.TryParse(input, out p) || (p < k - 1) || (p > 31)) return;

        Console.Write("Enter second start position (q, between {0} and 31): ", k - 1);
        input = Console.ReadLine();
        int q = 0;
        if (!int.TryParse(input, out q) || (q < k - 1) || (q > 31) || (p == q)) return;

        if (q>p) // if second parameter is greater than the first, exchanges them.
        {
            int temp = p;
            p = q;
            q = temp;
        }

        uint pmask = uint.MaxValue >> (32-k); // leaves only least k bits to 1, other 32-k to 0
        uint qmask = pmask << (q - k + 1); // shifts k-bits ot 1 to the start position q
        pmask = pmask << (p - k + 1); // shifts k-bits ot 1 to the start position p


        uint ptemp = number & pmask; // extracts (p,k) portion of bits from the number
        uint qtemp = number & qmask; // extracts (p,k) portion of bits from the number
        number = number & ~pmask & ~qmask; //zeroes bits in both p and q fields

		ptemp = ptemp >> (p - q); // positions "bit portions" in their new places
        qtemp = qtemp << (p - q);

        number = number | qtemp; // updates the number
        if ((p - q) < k) number = number & ~qmask; // if there is some intersection the first parameter p is prevailing
        number = number | ptemp;
        
        Console.WriteLine("\nThe updated number is " + number);
        Console.WriteLine("\nIts binary representation is:");
        Console.WriteLine("33222222222211111111110000000000");
        Console.WriteLine("10987654321098765432109876543210");
        Console.WriteLine("--------------------------------");
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
    }
}
