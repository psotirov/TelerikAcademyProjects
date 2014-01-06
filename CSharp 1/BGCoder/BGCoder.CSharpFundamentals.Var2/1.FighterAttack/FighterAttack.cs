using System;

class Plant
{
    int xLeft;
    int yTop;
    int xRight;
    int yBottom;

    public Plant(int x1, int y1, int x2, int y2)
    {
        xLeft = Math.Min(x1, x2);
        xRight = Math.Max(x1, x2);
        yTop = Math.Max(y1, y2);
        yBottom = Math.Min(y1, y2);
    }

    public bool Damage(int x, int y)
    {
        if (x < xLeft || x > xRight || y < yBottom || y > yTop) return false; // no damage 
        return true; // otherwise the hit is inside the body - true
    }
}

class FighterAttack
{
    static void Main()
    {
        Plant thePlant = new Plant( int.Parse(Console.ReadLine()), // reads the plant's coordinates: Px1,
                                    int.Parse(Console.ReadLine()), // Py1,
                                    int.Parse(Console.ReadLine()), // Px2,
                                    int.Parse(Console.ReadLine())  // Py2 (and sort them!) 
                               );

        int Fx = int.Parse(Console.ReadLine()); // reads the x coordinate of a fighter
        int Fy = int.Parse(Console.ReadLine()); // reads the y coordinate of a fighter
        int Dist = int.Parse(Console.ReadLine()); // reads the missale distance
        int damage = 0;

        damage += (thePlant.Damage(Fx + Dist, Fy)) ? 100 : 0; // if missle's main target is inside the plant - 100% damage
        damage += (thePlant.Damage(Fx + Dist, Fy - 1)) ? 50 : 0; // if missle's target to the left of main is inside the plant - 50% damage
        damage += (thePlant.Damage(Fx + Dist, Fy + 1)) ? 50 : 0; // if missle's target to the right of main is inside the plant  - 50% damage
        damage += (thePlant.Damage(Fx + Dist + 1, Fy)) ? 75 : 0; // if missle's target one cell forward of main is inside the plant  - 75% damage

        Console.WriteLine("{0}%", damage);
    }
}

