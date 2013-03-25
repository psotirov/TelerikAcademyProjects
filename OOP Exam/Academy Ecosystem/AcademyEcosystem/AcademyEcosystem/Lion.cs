using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Lion: Animal, ICarnivore
    {
        public Lion(string name, Point location)
            : base(name, location, 6)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null) return 0; // no such animal
            // the eaten animal should be at most twice by size than the lion
            if (animal.Size <= (this.Size*2))
            {
                // lion grows on each eat
                this.Size++;
                // take the food
                return animal.GetMeatFromKillQuantity();
            }
            // otherwise, go lion to grow enough, you are so small now
            return 0;
        }
    }
}
