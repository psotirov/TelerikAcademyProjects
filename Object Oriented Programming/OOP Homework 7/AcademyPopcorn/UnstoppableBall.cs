using System;


namespace AcademyPopcorn
{
    class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";
        public const char Symbol = '@';

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = Symbol;
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Racket.CollisionGroupString ||
                   otherCollisionGroupString == Block.CollisionGroupString || 
                   otherCollisionGroupString == UnpassableBlock.CollisionGroupString || 
                   otherCollisionGroupString == IndestructibleBlock.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            // this kind of ball must respond only to certain objects
            bool isRespondable = false;
            foreach (string colisionObj in collisionData.hitObjectsCollisionGroupStrings)
            {
                if (colisionObj == UnpassableBlock.CollisionGroupString || 
                    colisionObj == IndestructibleBlock.CollisionGroupString ||
                    colisionObj == Racket.CollisionGroupString)
                        isRespondable = true;
            }

            // if an object that must be responded to is found then call parent method (that make the exact responce) 
            if (isRespondable) base.RespondToCollision(collisionData); 
        }
    }
}
