using System;

class AgeCalculation
{
    static void Main()
    {
        int AgeNumber;
        Console.Write("Please enter your age: ");
        string Age = Console.ReadLine();
        if ((int.TryParse(Age, out AgeNumber)) && (AgeNumber>4) && (AgeNumber < 120))
        {
            Console.WriteLine("After a decade you will be {0} years old.", AgeNumber+10);
        }
        else Console.WriteLine("You entered an invalid value");
    }
}
