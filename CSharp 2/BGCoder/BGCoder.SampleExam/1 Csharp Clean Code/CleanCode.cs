using System;
using System.Text;

class CleanCode
{
    static void Main()
    {
        int linesN = int.Parse(Console.ReadLine());
        bool inComment = false; // until end of line comment
        bool docComment = false; // documentation comment - includes it into the output text, but not parsed anymore
        bool multilineComment = false; // multiline comment
        bool inString = false; // current character is in string literal (\" is not end of string) 
        bool escString = false; // current character is in @string literal ("" is not end of string)
        StringBuilder output = new StringBuilder();
        StringBuilder outLine = new StringBuilder();
        for (int line = 0; line < linesN; line++, inComment = false, docComment = false)
        {
            string code = Console.ReadLine();
            for (int pos = 0; pos < code.Length; pos++)
            {
                if (code[pos] == '/' && !inString && !escString && !inComment && !docComment) // we have comment candidate
                {
                    if (multilineComment && pos > 0 && code[pos - 1] == '*') // end of multiline comment
                    {
                        multilineComment = false;
                        continue; // goes to the next character
                    }

                    if (pos < code.Length - 1) 
                    {
                        if (code[pos + 1] == '/' && !multilineComment)
                        {
                            if (pos < code.Length - 2 && code[pos + 2] == '/') docComment = true; 
                            else inComment = true; // comment to the end of line
                        }
                        else if (code[pos + 1] == '*') multilineComment = true; // comment until the closing tag (*/)
                    }
                }

                if (code[pos] == '"' && !inComment && !multilineComment && !docComment) // probably we have string assignment
                {
                    bool isLiteral1 = (pos > 0 && code[pos - 1] == '\\'); // literal \" 
                    bool isLiteral2 = (pos > 0 && code[pos - 1] == '\'' && pos < code.Length - 1 && code[pos + 1] == '\''); // literal '"'
                    if (pos > 0 && code[pos - 1] == '@' && !escString) escString = true; // literal @" - start of esc string 
                    else if (!escString && !isLiteral1 && !isLiteral2) // we don't have above literals (or we have but inside @"" block)
                    {
                        inString = !inString; // inverts inString condition
                    }
                    else escString = false; // exits from escString condition 
                }

                if (!inComment && !multilineComment) outLine.Append(code[pos]);
            }

            if (multilineComment) continue; // we have multiline comment - goes to the next line
            if (outLine.ToString().Trim().Length == 0)
            {
                outLine.Clear(); // we have empty line
                continue; // goes to the next line
            }
            output.Append(outLine + "\r\n"); // puts final line into the buffer
            outLine.Clear(); // clears inline buffer
        }
        if (output.Length == 0) Console.WriteLine();
        else Console.Write(output); // we must not print new line since it is already into the buffer
        //Console.ReadLine();
    }
}
