using System;

namespace _02_Some_Statements
{
    class Statements
    {
        const int MinX = 0;
        const int MaxX = 100;
        const int MinY = 0;
        const int MaxY = 100;
 
        class Potato
        {
            public bool IsPeeled { get; set; }
            public bool IsRotten { get; set; }

            public Potato()
            {
                this.IsPeeled = false;
                this.IsRotten = false;

            }

            public void Cook()
            {
            }
        }

        static void Main(string[] args)
        {
            Potato potato = new Potato();
            // some code
            if (potato != null && potato.IsPeeled && potato.IsRotten)
            {
                potato.Cook();
            }

            // some more code
            bool shouldVisitCell = true;
            int cellX = 50;
            int cellY = 50;

            if (shouldVisitCell && (cellX >= MinX && cellX <= MaxX) && (cellY >= MinY && cellY <= MaxY))
            {
                VisitCell(cellY, cellX);
            }
        }

        private static void VisitCell(int row, int col)
        {
        }
           
    }
}
