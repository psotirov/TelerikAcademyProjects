using System;

class DifferentDataInputs
{

    enum InputType { intVar, doubleVar, stringVar };

    static void Main()
    {

        InputType itype = InputType.stringVar;
        Console.Write("Please enter integer, double or string value: ");
        string input = Console.ReadLine();
        int a = 0;
        double b = 0.0;
        if (int.TryParse(input, out a)) itype = InputType.intVar;
        else if (double.TryParse(input, out b)) itype = InputType.doubleVar;
 
        switch (itype)
        {
            case InputType.intVar:
                a += 1;
                Console.WriteLine("Integer value increased by one: " + a);
                break;
            case InputType.doubleVar:
                b += 1.0;
                Console.WriteLine("Double value increased by one: {0:F}", b);
                break;
            case InputType.stringVar:
                input = input + "*";
                Console.WriteLine("String value appended with asterix: " + input);
                break;
            default:
                break;
        }
    }
}

