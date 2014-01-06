using System;

namespace AcademyPopcorn
{
    // ExplodingObject must inherit Moving Object in order to destroy underlying static object using Collision Dispatcher
    class ExplodingObject : MovingObject
    {
        public ExplodingObject(MatrixCoords topLeft) // by default the lifetime is 3 turns
            : base(topLeft, new char[,] { { ExplodingBlock.Symbol } }, new MatrixCoords(0,0)) // generate exploding object body before invoking base constructor
        {
        }

        public override void Update() // updates the object lifetime
        {
            this.IsDestroyed = true; // it should disappear on the next tick 
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Block.CollisionGroupString || // this object should destroy underlying block object
                   otherCollisionGroupString == UnpassableBlock.CollisionGroupString; // but also unppassable block
        }
    }
}
