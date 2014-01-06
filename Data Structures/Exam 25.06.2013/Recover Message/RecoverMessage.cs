using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recover_Message
{
    class RecoverMessage
    {
        static string symbols = "";
        static string[] messages;
        static SortedSet<string> result = new SortedSet<string>();

        static void Main()
        {
            //Console.SetIn(new StreamReader(@"..\..\input.txt"));
            GetInput();

            GetPermutations("", 0);
            Console.WriteLine(result.Min);
        }

        static void GetInput()
        {
            int messagesCount = int.Parse(Console.ReadLine().Trim());
            messages = new string[messagesCount];
            for (int i = 0; i < messagesCount; i++)
            {
                messages[i] = Console.ReadLine().Trim();
                for (int l = 0; l < messages[i].Length; l++)
                {
                    if (!symbols.Contains(messages[i][l]))
                    {
                        symbols += messages[i][l];
                    }
                }
            }
        }

        static void GetPermutations(string output, int index)
        {
            if (index > 0 && !CheckMessagesPartially(output, index))
            {
                return;
            }

            if (index == symbols.Length)
            {
                //if (CheckMessages(output))
                //{
                //    result.Add(output);
                //}

                result.Add(output);
                return;
            }

            for (int i = 0; i < symbols.Length; i++)
            {
                if (!output.Contains(symbols[i]))
                {
                    GetPermutations(output + symbols[i], index + 1);
                }
            }
        }

        static bool CheckMessages(string output)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                int indexMessage = 0;
                for (int l = 0; l < output.Length; l++)
                {
                    if (output[l] == messages[i][indexMessage])
                    {
                        indexMessage++;
                        if (indexMessage == messages[i].Length)
                        {
                            break;
                        }
                    }
                }

                if (indexMessage < messages[i].Length)
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckMessagesPartially(string output, int index)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                if (symbols.Length - messages[i].Length > output.Length)
                {
                    continue;
                }

                int indexMessage = 0;
                for (int l = 0; l < output.Length; l++)
                {
                    if (output[l] == messages[i][indexMessage])
                    {
                        indexMessage++;
                        if (indexMessage == messages[i].Length || indexMessage == messages[i].Length - symbols.Length + index)
                        {
                            break;
                        }
                    }
                }

                if (indexMessage < messages[i].Length - symbols.Length + index)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
