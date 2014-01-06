using System;
using System.Collections.Generic;
using System.IO;

namespace _01_Students
{
    class Students
    {
        static void Main()
        {
            Console.WriteLine("Sorting external list of students on their courses");
            SortedDictionary<string, List<StudentNames>> students = new SortedDictionary<string, List<StudentNames>>();

            try
            {
                StreamReader file = new StreamReader(@"..\..\students.txt");
                using (file)
                {
                    while (!file.EndOfStream)
                    {
                        string[] dataLine = file.ReadLine().Split(new char[] {' ', '|'}, StringSplitOptions.RemoveEmptyEntries );
                        if (dataLine.Length == 3)
                        {
                            if (!students.ContainsKey(dataLine[2]))
                            {
                                students.Add(dataLine[2], new List<StudentNames>());                                
                            }

                            students[dataLine[2]].Add(new StudentNames(dataLine[0], dataLine[1]));
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Cannot read the input information", e);
                return;
            }

            foreach (var item in students)
            {
                Console.WriteLine("{0}: {{\n    {1}\n}}", item.Key, string.Join("\n    ", item.Value));
            }
        }
    }
}
