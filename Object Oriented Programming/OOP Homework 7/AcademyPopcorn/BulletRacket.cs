using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    class BulletRacket : Racket
    {
        private int shotsLeft; // Bullet Racket has limmited number of shots
        private bool hasShooted;
 
        public BulletRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.body[0, 0] = '!'; // draw left gun
            this.body[0, this.body.GetLength(1)-1] = '!'; // draw right gun
            this.shotsLeft = 10; // Bullet Racket has only 10 shots loaded
            hasShooted = false;
        }

        public bool Shoot()
        {
            this.shotsLeft--; // each shot is counted
            if (this.shotsLeft >= 0)
            {
                this.hasShooted = true; // enables shooting once
            }
            return (this.shotsLeft <= 0); // indicates if there is not any shots left 
        }
 
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> result = new List<GameObject>();
            if (hasShooted)
            {
                hasShooted = false;
                result.Add(new Bullet(this.topLeft));
                result.Add(new Bullet(this.topLeft + new MatrixCoords(0,this.body.GetLength(1)-1)));
            }
            return result;
        }
        
        public void AlignRacket(MatrixCoords topleft, int width) // helper method to update BulletRacket position on its creation
        {
            this.TopLeft = topleft;
            this.Width = width;
        }
    }
}
