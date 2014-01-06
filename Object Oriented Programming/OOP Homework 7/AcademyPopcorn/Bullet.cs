using System;

namespace AcademyPopcorn
{
    class Bullet : MovingObject // Bullet is a Moving Object that goes upwards with double speed until it hits any object
    {
        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '\'' } }, new MatrixCoords(-2, 0)) // apostrophe sign with speed -2
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString) // it collides only with blocks, gift blocks and indestructible blocks
        {
            return otherCollisionGroupString == Block.CollisionGroupString ||
                   otherCollisionGroupString == IndestructibleBlock.CollisionGroupString ||
                   otherCollisionGroupString == GiftBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true; // the result of collision is that the bullet is destroyed
        }
    }
}
