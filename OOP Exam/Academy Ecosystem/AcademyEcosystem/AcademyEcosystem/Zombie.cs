using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Zombie: Animal
    {
        public Zombie(string name, Point location)
            : base(name, location, 0)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            // Zombie cannot die, all carnivores take 10 meat in any case
            return 10;
        }
    }
}
