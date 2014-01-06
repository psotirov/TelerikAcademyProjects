using System;

class Problem1
{
    static void Main()
    {
        // temporary console input redirection
        //Console.SetIn(new System.IO.StreamReader("test.001.in.txt"));
        string[] digits = new string[9] {"-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        
        string input = Console.ReadLine();
        string digit = "";
        ulong decoded = 0;
        for (int i = 0; i < input.Length; i++)
        {
            int digitIdx = -1;
            digit += input[i];
            switch (digit.Length)
            {
                case 2:
                    digitIdx = 0;
                    if (digit.CompareTo(digits[digitIdx]) == 0) break;
                    digitIdx = 1;
                    if (digit.CompareTo(digits[digitIdx]) == 0) break;
                    digitIdx = 3;
                    if (digit.CompareTo(digits[digitIdx]) == 0) break;
                    digitIdx = 4;
                    if (digit.CompareTo(digits[digitIdx]) == 0) break;
                    digitIdx = 5;
                    if (digit.CompareTo(digits[digitIdx]) != 0) continue;
                    break;
                case 3:
                    digitIdx = 2;
                    if (digit.CompareTo(digits[digitIdx]) == 0) break;
                    digitIdx = 7;
                    if (digit.CompareTo(digits[digitIdx]) != 0) continue;
                    break;
                case 4:
                    digitIdx = 6;
                    if (digit.CompareTo(digits[digitIdx]) != 0) continue;
                    break;
                case 6:
                    digitIdx = 8;
                    if (digit.CompareTo(digits[digitIdx]) != 0) continue;
                    break;
                default:
                    continue;
            }
            decoded = decoded * 9 + (ulong)digitIdx;
            digit = "";            
        }

        Console.WriteLine(decoded);
        //Console.ReadLine();
    }
}
