using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class GiftBlock : Block
    {
        public new const string CollisionGroupString = "giftBlock";
        public const char Symbol = '$';

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlock.Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return GiftBlock.CollisionGroupString;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> result = new List<GameObject>();
            if (this.IsDestroyed) // if the Exploding block is hit, there is explosion
            {
                //adds all falling Gift at the same position
                result.Add(new Gift(this.TopLeft));
            }

            return result;
        }
    } 
}
