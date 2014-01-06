using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Boar: Animal, ICarnivore, IHerbivore
    {
        private int biteSize;

        public Boar(string name, Point location)
            : base(name, location, 4)
        {
            this.biteSize = 2;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal == null) return 0; // no such animal

            // the eaten animal should be smaller than or equal to the boar
            if (animal.Size <= this.Size)
            {
                // take the food
                return animal.GetMeatFromKillQuantity();
            }
            // otherwise no food for the boar, go to eat plants first
            return 0;
        }

        public int EatPlant(Plant plant)
        {
            if (plant == null) return 0; // no such plant

            // Boar grows on each eat
            this.Size++;
            return plant.GetEatenQuantity(this.biteSize);
        }
    }
}
