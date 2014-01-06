using System;
using System.Collections.Generic;
using System.IO;

namespace _02_Traverse_Directories
{
    class TraverseDirectories
    {
        static int totalDirs = 1;
        static int totalDirsShown = 0;
        static int totalExeFiles = 0;

        static void Main()
        {
            Console.BufferHeight = 10000;
            string dirPath = @"\WINDOWS";
            Console.WriteLine("List of all directories in {0}, containing *.exe files", dirPath);

            PrintDirectories(dirPath);
            Console.WriteLine("\n\nTotal {0} directories found ({1} shown).", totalDirs, totalDirsShown);
            Console.WriteLine("Total {0} *.exe files found.", totalExeFiles);
        }

        static void PrintDirectories(string dir)
        {
            try
            {
                var exeFiles = new List<string>(Directory.EnumerateFiles(dir, "*.exe"));
                if (exeFiles.Count > 0)
                {
                    Console.WriteLine("\nDirectory: {0}", dir);
                    totalDirsShown++;
                    foreach (string exeFile in exeFiles)
                    {
                        Console.Write("{0} ", exeFile.Substring(dir.Length + 1));
                    }

                    Console.WriteLine("\n{0} files found.", exeFiles.Count);
                    totalExeFiles += exeFiles.Count;
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips dir silently
            }

            try
            {
                var dirs = new List<string>(Directory.EnumerateDirectories(dir));
                totalDirs += dirs.Count;
                foreach (var subDir in dirs)
                {
                    // Shows all subdirectories recursively 
                    PrintDirectories(subDir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips dir silently
            }
        }
    }
}
