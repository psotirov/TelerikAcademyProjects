using System;

class VariousTypesAssignments
{
    public struct FirmEmployee //Structure as per Task 10 (see below)
    {
        public string FirstName;
        public string LastName;
        public byte Age;
        public bool isMale;
        public uint IDnumber;
        public uint EmployeeNumber;
    }

    public struct BankAccount //Structure as per Task 14 (see below)
    {
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string BankName;
        public string BankBIC;
        public string IBAN;
        public decimal Balance; 
        public ulong CardNumber1;
        public ulong CardNumber2;
        public ulong CardNumber3;
    }

    static void Main()
    {
        // Task 4 - Hexadecimal Integer
        int a = 0xFE;
        Console.WriteLine("Decimal: {0}, Hexadecimal: {0:X}\n", a);

        // Task 5 - Unicode Character
        char symbol = '\u0048';
        Console.WriteLine(symbol);

        // Task 6 - Boolean - Gender
        bool isFemale = false;
        Console.WriteLine("\nMy gender is {0}\n", (isFemale)?"Female":"Male");

        // Task 7 - String and Object Assignments
        string FirstStr = "Hello";
        string SecondStr = "World";
        object ConcatStr = FirstStr + " " + SecondStr;
        string ResultStr = (string)ConcatStr;
        Console.WriteLine(ConcatStr);

        // Task 8 - Using quotes
        string Quotes = "\nThe \"use\" of quotations causes difficulties.";
        Console.WriteLine(Quotes);
        Quotes = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(Quotes);

        // Task 10 - Employee Record
        FirmEmployee Test = new FirmEmployee();
        Test.FirstName = "Pavel";
        Test.LastName = "Sotirov";
        Test.Age = 41;
        Test.isMale = true;
        Test.IDnumber = 123456789;
        Test.EmployeeNumber = 27560001;
        Console.WriteLine("\nFirst Name: " + Test.FirstName);
        Console.WriteLine("Last Name: " + Test.LastName);
        Console.WriteLine("Age: " + Test.Age);
        Console.WriteLine("Gender: {0}", (Test.isMale)?"Male":"Female");
        Console.WriteLine("ID Number: " + Test.IDnumber);
        Console.WriteLine("Employee Number: " + Test.EmployeeNumber);

        // Task 11 - Exchange integer values
        int A = 5;
        int B = 10;
        Console.WriteLine("\nA = {0}, B = {1}", A, B);
        A = A + B;
        B = A - B;
        A = A - B;
        Console.WriteLine("A = {0}, B = {1}", A, B);

        // Task 13 - null values
        int? aNullable = null;
        double? bNullable = null;
        Console.WriteLine("\nint: {0}, double: {1}", aNullable, bNullable);
        aNullable += 10;
        bNullable += 10d;
        Console.WriteLine("int: {0}, double: {1}", aNullable, bNullable);

        // Task 14 - Bank Account Record
        BankAccount TestAccount = new BankAccount();
        TestAccount.FirstName = "Pavel";
        TestAccount.MiddleName = "Ivanov";
        TestAccount.LastName = "Sotirov";
        TestAccount.BankName = "Unicredit Bulbank";
        TestAccount.BankBIC = "UNCRBGSF";
        TestAccount.IBAN = "BG00UNCR70001010101010";
        TestAccount.CardNumber1 = 1234567890123456;
        TestAccount.CardNumber2 = 1234567890123457;
        TestAccount.CardNumber3 = 1234567890123458;
        TestAccount.Balance = 4100m; 
        Console.WriteLine("\nFirst Name: " + TestAccount.FirstName);
        Console.WriteLine("Middle Name: " + TestAccount.MiddleName);
        Console.WriteLine("Last Name: " + TestAccount.LastName);
        Console.WriteLine("Bank: " + TestAccount.BankName);
        Console.WriteLine("Bank BIC Code: " + TestAccount.BankBIC);
        Console.WriteLine("Bank Account IBAN: " + TestAccount.IBAN);
        Console.WriteLine("Credit Card 1 Number: " + TestAccount.CardNumber1);
        Console.WriteLine("Credit Card 2 Number: " + TestAccount.CardNumber2);
        Console.WriteLine("Credit Card 3 Number: " + TestAccount.CardNumber3);
        Console.WriteLine("Balance: {0:C2}\n", TestAccount.Balance);
    }
}

