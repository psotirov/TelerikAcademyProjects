using System;
using System.Text;

class Factorial
{
    static void Main()
    {
        Console.WriteLine("Task 10 - Calculates the factorial N!\n\n");

        int dimN = 0;
        Console.Write("Please enter factorial N [3, 100]: ");
        if (!int.TryParse(Console.ReadLine(), out dimN) || dimN < 3 || dimN > 100) // wrong factorial value
        {
            Console.WriteLine("Not a valid factorial falue");
            return;
        }

        StringBuilder factorial = new StringBuilder("1");

        for (int i = 2; i <= dimN; i++)
        {
            factorial = Multiply(factorial, i);
        }

        Console.WriteLine("\nThe {0}! is {1}", dimN, factorial.ToString());

        Console.WriteLine("\nPlease hit Enter to finish");
        Console.ReadLine();
    }

    static StringBuilder Multiply(StringBuilder fact, int number)
    {
        
StringBuilder result = new StringBuilder();
        int position = 0; // digit position in number  
        while (number > 0)
        {
            int digit = number % 10; // extracts last digit

            if (digit > 0) // multily digit by fact
            {
                StringBuilder partial = new StringBuilder(); // partial result of multiplication of fact and digit 

                // fact * digit << position
                int carry = 0; // the overflow of multiplication
                for (int i = fact.Length-1; i >= 0; i--) // itearates through each "digit" of factorial from least to most place
                {
                    carry += (fact[i] - '0')*digit;
                    partial.Insert(0, (char)(carry % 10 + '0')); 
                    carry /= 10;
                }
                if (carry > 0) partial.Insert(0, (char)(carry + '0'));

                if (position == 0) result = partial; // result is empty so takes the vlue of partial directly
                else
                {
                    partial.Append(new String('0', position)); // adds required trailing zeroes to the result

                    // result = result + partial
                    if (result.Length < partial.Length) result.Insert(0, new string('0', partial.Length - result.Length));
                    // adds leading zeroes in order to make both lengths equal 
                    carry = 0; // the overflow of adding
                    for (int i = partial.Length - 1; i >= 0; i--) // itearates through each "digit" of partial result from least to most place
                    {
                        carry += (result[i] - '0') + (partial[i] - '0');
                        result[i] = (char)(carry % 10 + '0');
                        carry /= 10;
                    }
                    if (carry > 0) result.Insert(0, (char)(carry + '0'));
                }
            }
            number /= 10;
            position++;
        }

        return result; // returns updated factorial 
    }
}
