using System;

namespace CodeFragment
{
    class DoSomething
    {
        const int MaxCount = 6;

        class DoSomethingInside
        {
            public void PrintBool(bool variable)
            {
                string variableToString = variable.ToString();
                Console.WriteLine(variableToString);
            }
        }

        static void Main()
        {
            DoSomethingInside instance = new DoSomethingInside();
            instance.PrintBool(true);
        }
    }
}
