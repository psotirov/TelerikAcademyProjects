using System;

namespace CohesionAndCoupling
{
    class Examples
    {
        static void Main()
        {
            Console.WriteLine(FileName.GetFileExtension("example"));
            Console.WriteLine(FileName.GetFileExtension("example.pdf"));
            Console.WriteLine(FileName.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileName.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Distance.Calc2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Distance.Calc3D(5, 2, -1, 3, -6, 4));

            Cuboid.Width = 3;
            Cuboid.Height = 4;
            Cuboid.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", Cuboid.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Cuboid.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Cuboid.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Cuboid.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Cuboid.CalcDiagonalYZ());
        }
    }
}
