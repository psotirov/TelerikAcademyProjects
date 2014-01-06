using System;
using System.IO;

namespace _01_04_3DPoints
{
    public static class PathStorage
    {
        // file format is:
        // at first line - N, the number of points into the path
        // at each consecutive N lines - point coordinates X, Y, Z, separated by spaces
        public static Path Read(string filename) // reads path from file
        {
            Path result = new Path();
            using (StreamReader sr = new StreamReader(filename)) // if something goes wrong, a standard exception procedure will take place
            {
                int cnt = int.Parse(sr.ReadLine()); // reads number of points of the path 
                for (int i = 0; i < cnt; i++)
                {
                    string[] coords = sr.ReadLine().Split(' '); // reads each point (X,Y,Z, separated by spaces) 
                    int x = int.Parse(coords[0]);
                    int y = int.Parse(coords[1]);
                    int z = int.Parse(coords[2]);
                    result.Add(x, y, z); // and loads it into the path
                }
            }

            return result; // finally returns the path
        }
        public static void Write(Path source, string filename) // writes path to file
        {
            using (StreamWriter sw = new StreamWriter(filename)) // if something goes wrong, a standard exception procedure will take place
            {
                sw.WriteLine(source.Count); // writes number of points of the path
                foreach (Point3D item in source)
                {
                    sw.WriteLine("{0} {1} {2}", item.X, item.Y, item.Z); // writes each point into the path on a separate line
                }
            }
        }
    }
}
