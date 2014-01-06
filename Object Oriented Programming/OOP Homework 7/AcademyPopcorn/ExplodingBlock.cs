using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        public new const string CollisionGroupString = "explodingBlock";
        public const char Symbol = '*';

        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Block.CollisionGroupString;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> result = new List<GameObject>();
            if (this.IsDestroyed) // if the Exploding block is hit, there is explosion
            {
                //adds all surrounding cells to the explosion
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(-1, -1)));
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(-1, 0)));
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(-1, 1)));
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(0, -1)));
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(0, 1)));
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(1, -1)));
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(1, 0)));
                result.Add(new ExplodingObject(this.TopLeft + new MatrixCoords(1, 1)));
            }

            return result;
        }
    } 
}
