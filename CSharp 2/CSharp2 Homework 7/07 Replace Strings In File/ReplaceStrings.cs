using System;
using System.IO;
using System.Text;

class ReplaceSubstrings
{
    static void Main()
    {
        const int BUFFER = 2000; // read/write buffer size
        Console.WriteLine("Task 07 - Replace substrings in a given text file\n\n");
        string[,] dict = new string[,] { { "start" }, { "finish" } }; // replace substrings dictionary

        Console.Write("Please enter the name and path to the text file: ");
        string filename1 = Console.ReadLine();
        Console.Write("Please enter the name and path to the output text file: ");
        string filename2 = Console.ReadLine();

        StringBuilder buffer = new StringBuilder(BUFFER+100); // creates output buffer
        char[] buf = new char[BUFFER]; // creates char[] input buffer as required by Read method

        // creates a character buffer with capacity greater than the exact read size due to different length of dictionary pairs

        try
        {
            using (StreamReader reader = new StreamReader(filename1))
            {
                using (StreamWriter writer = new StreamWriter(filename2))
                {
                    while (!reader.EndOfStream)
                    // in order to avoid out of memory exeption for very big files we are accessing input/output files
                    // through a buffer "window" of about 2K (4K in memory), as set in const int BUFFER
                    {
                        string temp = ""; // temp variable for "end of buffer" purposes (see below)
                        reader.Read(buf, 0, BUFFER); // reads some data inside
                        buffer.Append(buf); // transfers it to the StringBuilder buffer
                        for (int i = 0; i < dict.GetLength(1); i++) // for each word in dictionary
			            {
			                buffer.Replace(dict[0,i], dict[1,i]); // replaces with the corresponding substring
                            // now we have A BIG PROBLEM - the buffer can end at the middle of a searched substring
                            for (int j = 1; j < dict[0,i].Length; j++) // checks for each substring of the dictionary word with length [1,Length]
                            {
                                if (dict[0, i].Substring(0, j) == buffer.ToString(buffer.Length - j, j)) // we have equal substring
                                {
                                    temp = dict[0, i].Substring(0, j); //save this part of the dictionary word
                                    buffer.Remove(buffer.Length - j, j); // removes it from the output buffer
                                }
                            }
			            }                       
                        writer.Write(buffer); // writes it
                        writer.Flush();
                        buffer.Clear(); // and clears the buffer
                        if (temp.Length > 0) buffer.Append(temp); // if necessary adds the removed substring to the begining if the next buffer portion
                    }
                }
            }
        }
        catch (SystemException se)
        {
            Console.WriteLine("Exception: " + se);
            return;
        }

        Console.WriteLine("\n\n{0} was copied to {1} with requested changes", filename1, filename2);

        Console.WriteLine("\nPress Enter to finish");
        Console.ReadLine();
    }
}