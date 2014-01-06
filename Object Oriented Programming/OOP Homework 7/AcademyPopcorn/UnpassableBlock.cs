using System;

namespace AcademyPopcorn
{
    public class UnpassableBlock : Block
    {
        public new const string CollisionGroupString = "unpassableBlock";
        public const char Symbol = 'X';

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            // the following code gives possibility an Unpassable Block to be destroyed by Explosion Block's Explosion Object!
            foreach (string colisionObj in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (colisionObj == ExplodingObject.CollisionGroupString)
                         base.RespondToCollision(collisionData);
            }
        }
    }
}
