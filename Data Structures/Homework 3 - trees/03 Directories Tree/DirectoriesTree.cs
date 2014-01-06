using System;
using System.IO;

namespace _03_Directories_Tree
{
    class DirectoriesTree
    {
        static int totalDirs = 1;
        static int totalFiles = 0;

        static void Main()
        {
            string dirPath = @"\WINDOWS";
            Console.WriteLine("Creates directory tree of all directories in {0} and containing files\n", dirPath);
            DirectoryInfo rootDir = new DirectoryInfo(dirPath);
            Folder root = new Folder(rootDir.FullName);

            GetDirectoriesTree(root, rootDir);
            Console.WriteLine("\n\nTotal {0} directories found.", totalDirs);
            Console.WriteLine("Total {0} files found.", totalFiles);
            long rootLength = root.FolderSize();
            Console.WriteLine("\nTotal size of {0} is {1:N0} bytes ({2:N3} GB).", root.Name, rootLength, rootLength / (double)1073741824);
            Console.WriteLine("\nCheck it in Windows Explorer, it should be almost equal (due to some access issues)");
        }

        static void GetDirectoriesTree(Folder root, DirectoryInfo currentDir)
        {
            // fetch files
            try
            {
                var currentDirFiles = currentDir.EnumerateFiles();
                foreach (var file in currentDirFiles)
                {
                    root.AddFile(file.Name, Convert.ToInt32(file.Length));
                    totalFiles++;
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips file silently
            }

            // fetch directories using DFS
            try
            {
                var currentSubDirs = currentDir.EnumerateDirectories();
                foreach (var subDir in currentSubDirs)
                {
                    var subFolder = root.AddFolder(subDir.Name);
                    totalDirs++;
                    if (totalDirs % 1000 == 0)
                    {
                        ShowProgress();
                    }
                    GetDirectoriesTree(subFolder, subDir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips dir silently
            }
        }

        static void ShowProgress()
        {
            Console.Write(".");
        }
    }
}
