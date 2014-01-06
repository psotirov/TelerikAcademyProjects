using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class Gift : MovingObject // the gift is a Moving Object
    {
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '$' } }, new MatrixCoords(2, 0)) // it moves down with a double speed
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString) 
        {
            return otherCollisionGroupString == Racket.CollisionGroupString; // it can collide only with Racket
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true; // the result of Racket colliding is tht the gift is destroyed
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> result = new List<GameObject>();
            if (this.IsDestroyed) // when the gift reaches the Racket
            {
                result.Add(new BulletRacket(this.topLeft, 6)); // it "converts" to Bullet Racket
            }
            return result;
        }
    }
}
