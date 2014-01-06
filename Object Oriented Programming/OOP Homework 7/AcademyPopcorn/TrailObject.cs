using System;

namespace AcademyPopcorn
{
    class TrailObject:GameObject
    {
        public const char Symbol = '.'; // trail object body symbol
        public int TimeToLive { get; protected set; } // adds property that holds a lifetime of this temporary object

        public TrailObject(MatrixCoords topLeft, int live=3) // by default the lifetime is 3 turns
            : base(topLeft, new char[,] { { TrailObject.Symbol } }) // generate trail object body before invoking base constructor
        {
            this.TimeToLive = live;
        }

        public override void Update() // updates the object lifetime
        {
            this.TimeToLive--;
            if (this.TimeToLive <= 0) this.IsDestroyed = true; // each object with 0 lifetime must be destroyed 
        }
    }
}
