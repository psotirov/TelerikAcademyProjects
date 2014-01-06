using System;

class CompanyRecord
{
    static void Main()
    {

        string[,] CompRecord = new string[,]
        {
            {"Company Name",""},
            {"Company Address",""},
            {"Company Phone Number",""},
            {"Company Fax Number",""},
            {"Company Website",""},
            {"Manager First Name",""},
            {"Manager Last Name",""},
            {"Manager Age",""},
            {"Manager Phone Number",""}
        };
        for (int i = 0; i < CompRecord.GetLength(0); i++)
        {
            Console.Write("Please enter {0}: ",CompRecord[i,0]);
            CompRecord[i, 1] = Console.ReadLine();
        }
        Console.WriteLine("\n\nThe Company Record contains:");
        for (int i = 0; i < CompRecord.GetLength(0); i++)
        {
            Console.WriteLine("{0,-30}{1}", CompRecord[i, 0]+":", CompRecord[i, 1]);
        }

    }
}

