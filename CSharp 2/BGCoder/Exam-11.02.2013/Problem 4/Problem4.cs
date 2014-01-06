using System;
using System.Text;

class Problem4
{
    static void Main()
    {
        // temporary console input redirection
        // Console.SetIn(new System.IO.StreamReader("test.002.in.txt")); (!!! thanks to "jasssonpet" for the idea !!!)
        StringBuilder input = new StringBuilder(); // holds all input lines (including \n characters)

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            input.Append(Console.ReadLine() + "\n");
        }

        // calls evaluation method and prints the output result (OBVIOUSLY)
        // but here the method is invoked withour any surrounding tags, i.e. pure text
        Console.Write(Evaluate(input).ToString());
        //Console.ReadLine();
    }

    static StringBuilder Evaluate(StringBuilder buffer, string tag = "")
    {
        // the method walks through "buffer" character by character
        // and prints any of them to the output in accordance to the type of surrounding pair of tags
        // if a pair of tags are found inside the buffer
        // the method calls itself with the text inside those tags (using recursion)
        // then the result is "replaced" within the buffer.

        StringBuilder result = new StringBuilder();
        if (tag == "del") return result; // if surroundng tag is del - returns empty result
        bool isTag = false; // indicates if we are reading the tag name
        bool inTag = false; // indicates if we are reading the text between pair of tags
        StringBuilder anyTag = new StringBuilder(); // holds the tag name of any found tag in the text
        StringBuilder openTag = new StringBuilder(); // holds the tag name of the relevant opening tag
        StringBuilder toEvaluate = new StringBuilder(); // holds the text between a pair of tags
        int nestedEqualTags = 0; // counts how many equal opening tags are found (the same number of closing tags we must have to make a pair)

        for (int i = 0; i < buffer.Length; i++)
        {
            char symbol = buffer[i];
            if (!isTag && symbol == '<') // tag start
            {
                isTag = true;
                continue;
            }

            if (isTag && symbol == '>') // tag end
            {
                isTag = false;
                if (openTag.Length == 0) // we don't have any opening tags up to the moment
                {
                    openTag.Append(anyTag);
                    inTag = true;
                    anyTag.Clear();
                }
                else
                {
                    if (openTag.Equals(anyTag)) nestedEqualTags++; // a new equal opening tag has been found - counts it
                    if (anyTag[0] == '/' && openTag.ToString() == anyTag.ToString(1, anyTag.Length - 1) && nestedEqualTags == 0)
                    // the closing tag that makes pair with the opening tag has been found
                    {
                        inTag = false;
                        // we already have a pair of tags inside the buffer - evaluates it
                        toEvaluate = Evaluate(toEvaluate, openTag.ToString());
                        // and then saves the result into buffer but after current position 
                        if (i == buffer.Length - 1) // if end of buffer has been found
                        {
                            buffer.Append(toEvaluate); // appends it to the end of buffer
                        }
                        else
                        {
                            buffer.Insert(i+1, toEvaluate); // otherwise iserts it
                        }
                        anyTag.Clear();
                        openTag.Clear();
                        toEvaluate.Clear(); // clears all tag holders
                    }
                    else // we don't have a pair of tags or the pair is not the most outer one
                    {
                        // if we have more than one equal opening tags - counts the inner pair of them
                        if (anyTag[0] == '/' && openTag.ToString() == anyTag.ToString(1, anyTag.Length - 1)) nestedEqualTags--; 
                        // since this is not the most outer tag puts it to the evaluation buffer
                        toEvaluate.Append("<" + anyTag + ">");
                        anyTag.Clear(); // clears the tag appended already
                    }
                }
                continue; // goes to the next buffer position
            }

            if (!isTag && !inTag) // standard output
            {
                switch (tag) // do the job of the corresponding tag  
                {
                    case "upper":
                        result.Append(char.ToUpper(symbol));
                        break;
                    case "lower":
                        result.Append(char.ToLower(symbol));
                        break;
                    case "toggle":
                        if (Char.IsUpper(symbol)) result.Append(char.ToLower(symbol)); // toggles the case of the character
                        else result.Append(char.ToUpper(symbol));
                        break;
                    case "rev":
                        result.Insert(0, symbol); // text reversing is implemented through insert at the current buffer begining 
                        break;
                    default:
                        result.Append(symbol); // normal text is just appended to the end of the current buffer 
                        break;
                }
            }
            else if (isTag) //we are reading tag name
            {
                anyTag.Append(symbol);
            }
            else // we are in nested tag - just append to the evaluation buffer for further processing
            {
                toEvaluate.Append(symbol);
            }

        }

        return result; 
    }
}

