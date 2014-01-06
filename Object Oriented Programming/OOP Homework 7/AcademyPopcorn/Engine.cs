using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        protected Racket playerRacket; // this field must be accessible to ShootingEngine class also
        int SpeedDelay { get; set; } // adds speed to engine (property, constructor parameter, implementation)

        public Engine(IRenderer renderer, IUserInterface userInterface, int speed=200) // speed of 200ms by default
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
            this.SpeedDelay = speed; // assigns property value
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            // initially removes the previous racket (if any) from the list of all objects and static objects
            int prevIdx = this.staticObjects.FindIndex((gobj) => gobj is Racket); // uses lambda predicate to search for Racket
            if (prevIdx >= 0)
            {
                if (obj is BulletRacket)
                {
                    // updates the coordinates and width of new racket to be the same as old one     
                    (obj as BulletRacket).AlignRacket(this.staticObjects[prevIdx].TopLeft, (this.staticObjects[prevIdx] as Racket).Width);
                }
                this.staticObjects.RemoveAt(prevIdx);
            }

            prevIdx = this.allObjects.FindIndex((gobj) => gobj is Racket);
            if (prevIdx >= 0) this.allObjects.RemoveAt(prevIdx);

            // then applies the new one
            this.playerRacket = obj as Racket;
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(this.SpeedDelay); // implementation of changeable speed

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}
