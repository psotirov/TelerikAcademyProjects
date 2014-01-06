using System;

class Ship
{
    int xLeft;
    int yTop;
    int xRight;
    int yBottom;

    public Ship(int x1, int y1, int x2, int y2)
    {
        xLeft = Math.Min(x1, x2);
        xRight = Math.Max(x1, x2);
        yTop = Math.Max(y1, y2);
        yBottom = Math.Min(y1, y2);
    }

    public int Damage(int x, int y)
    {
        if (x < xLeft || x > xRight || y < yBottom || y > yTop) return 0; // no damage 
        if (x == xLeft || x == xRight)
        {
            if (y == yBottom || y == yTop) return 25; // 25% damage - corner was hit
            else return 50; // 50% damage - side was hit
        }

        if (y == yBottom || y == yTop)
        {
            if (x == xLeft || x == xRight) return 25; // 25% damage - corner was hit
            else return 50; // 50% damage - side was hit
        }

        return 100; // otherwise the hit is inside the body - 100%
    }
}

class ShipDamage
{
    static void Main()
    {
        Ship theShip = new Ship(    int.Parse(Console.ReadLine()), // reads the ship's coordinates: Sx1,
                                    int.Parse(Console.ReadLine()), // Sy1,
                                    int.Parse(Console.ReadLine()), // Sx2,
                                    int.Parse(Console.ReadLine())  // Sy2 (and sort them!) 
                               );

        int Hy = int.Parse(Console.ReadLine()); // reads the horizon line
        int Damage = 0;

        for (int i = 0; i < 3; i++)
        {
            int Cx = int.Parse(Console.ReadLine()); // reads the x coordinate of i-th cathapult
            int Cy = int.Parse(Console.ReadLine()); // reads the y coordinate of i-th cathapult
            Damage += theShip.Damage(Cx, Hy + (Hy - Cy)); // transfers the Cy coordinate at the opposite side of horizon
        }

        Console.WriteLine("{0}%", Damage);
    }
}

