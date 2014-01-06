using System;

namespace _01_04_3DPoints
{
    class TestPoints3D
    {
        static void Main()
        {
            Console.WriteLine("Testing 3D Points, Path and Path Storage....\r\n");
            
            Console.WriteLine("Enter a path as a sequence of 3D points (x y z, separated with spaces, one per line)\r\nFinish with 0,0,0 or wrong input");
            Path p1 = new Path();
            try
            {
                while (true)
                {
                    Console.Write("Point {0}: ", p1.Count + 1);
                    string[] coords = Console.ReadLine().Split(' '); // reads each point (X,Y,Z, separated by spaces) 
                    int x = int.Parse(coords[0]);
                    int y = int.Parse(coords[1]);
                    int z = int.Parse(coords[2]);
                    if (x == 0 && y == 0 && z == 0) break; // finishes input on {0,0,0}
                    p1.Add(x, y, z); // and loads it into the path
                    // calculates the distance between last two entered points  
                    if (p1.Count > 1) Console.WriteLine("Distance:" + Distance3D.Calc(p1[p1.Count - 1], p1[p1.Count - 2]));
                    else Console.WriteLine("Distance:" + Distance3D.Calc(p1[p1.Count - 1], Point3D.O));
                }
            }
            catch
            {           
            }

            Console.WriteLine("The result is " + p1);
            Console.WriteLine("Saves to text file and reads back to another variable");
            PathStorage.Write(p1, "..\\..\\testpath.txt");
            Path p2 = PathStorage.Read("..\\..\\testpath.txt");
            Console.WriteLine(p2);

            Console.WriteLine("press Enter to finish");
            Console.ReadLine();
        }
    }
}
