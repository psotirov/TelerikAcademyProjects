using System;
using System.Text;

class GenomeDecoder
{
    static StringBuilder decoded = new StringBuilder(); // output data container
    static int lineNr = 0; // starting line number
    static int linePos = 0; // current character position in current line 
    static int lineLenN = 0; // total length of decoded genome line
    static int groupLenM = 0; // length of decoded genome group
    static string leadSpaces = "!      "; // leading spaces formatting tag (!-identifier + 6 spaces since max length of decoded string is 100 000)

    static void Main()
    {
        // temporary console input redirection
        // Console.SetIn(new System.IO.StreamReader("test.000.002.in.txt"));

        // reads formatting parameters
        string[] fp = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        lineLenN = int.Parse(fp[0]);
        groupLenM = int.Parse(fp[1]);

        string encoded = Console.ReadLine();
        int count = 0;

        for (int i = 0; i < encoded.Length; i++)
        {
            int digit = encoded[i] - '0';
            if (digit >= 0 && digit <= 9) // we are in the number part of encoded genome
            {
                count = count * 10 + digit; // add current digit to the number
            }
            else // we are in the symbol part of encoded genome
                if (count == 0) // we have a single symbol in the decoded genome
                {
                    GenomeQueue(encoded[i].ToString());
                }
                else // we have "count" number of symbols in the decoded genome
                {
                    GenomeQueue(new string(encoded[i], count));
                    count = 0;
                }
        }

        // adjusts leading spaces at the begining of each line
        decoded.Replace(leadSpaces, ""); // removes unnecessary leading characters

        // prints the output
        Console.WriteLine(decoded);
    }

    static void GenomeQueue(string parse)
    {
        for (int i = 0; i < parse.Length; i++) //iterates through each character of the parse string
        {
            if (linePos == 0) // starting a new line
            {
                if ((lineNr++).ToString().Length < lineNr.ToString().Length) // the new line number requires 1 leading space less than previous 
                    leadSpaces = leadSpaces.Substring(0, leadSpaces.Length - 1);
                if (lineNr > 1) decoded.Append("\r\n"); // adds a new line for each new line number (ecxept 1)
                decoded.Append(leadSpaces + lineNr.ToString() + " "); // adds leading data
            }

            if (linePos > 0 && linePos % groupLenM == 0) decoded.Append(" "); // adds group space if needed
            decoded.Append(parse[i]);
            linePos++;
            if (linePos == lineLenN) linePos = 0; // adjusts line position if end of line has been reached
        }
    }
}
