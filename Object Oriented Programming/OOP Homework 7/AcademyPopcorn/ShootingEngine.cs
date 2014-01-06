using System;

namespace AcademyPopcorn
{
    class ShootingEngine : Engine
    {
        public ShootingEngine(IRenderer renderer, IUserInterface userInterface, int speed = 200)
            : base(renderer, userInterface, speed)
        {
        }

        public void ShootPlayerRacket() // Shooting even has occured
        {
            if (this.playerRacket is BulletRacket) // checks if the Racket has shooting capability
            {
                // then take a shot
                if ((this.playerRacket as BulletRacket).Shoot())
                {
                    // after a shoot, if all the shots has been used, return back to normal Racket
                    this.AddObject(new Racket(this.playerRacket.TopLeft, this.playerRacket.Width)); 
                }
            }
        }
    }
}
