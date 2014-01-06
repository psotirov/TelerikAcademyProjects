using System;
using System.Collections.Generic;


namespace AcademyPopcorn
{
    class MeteoriteBall : Ball
    {
        public new const string CollisionGroupString = "meteoriteBall"; // adds meteoriteBall in the Game object namespace
        public const char Symbol = 'O'; // changes the ball view

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = Symbol; // changes the ball view
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> result = new List<GameObject>();
            result.Add(new TrailObject(this.TopLeft)); // producing a trail object on current ball position 
            return result;
        }

        public override string GetCollisionGroupString() // returns "meteoriteBall" Game object name
        {
            return MeteoriteBall.CollisionGroupString;
        }
    }
}
