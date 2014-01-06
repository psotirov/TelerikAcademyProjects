using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public interface ICollidable
    {
        bool CanCollideWith(string objectType);

        List<MatrixCoords> GetCollisionProfile();

        void RespondToCollision(CollisionData collisionData);

        string GetCollisionGroupString();
    }
}
