using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Grass: Plant
    {
        public Grass(Point location)
            : base(location, 2)
        {
        }

        public override void Update(int time)
        {
            // the grass is growing 1 size at a time, but only if it is alive
            if (this.IsAlive) this.Size += time;
        }
    }
}
