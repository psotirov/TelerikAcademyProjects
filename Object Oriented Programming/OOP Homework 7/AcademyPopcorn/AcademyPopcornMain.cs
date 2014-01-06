using System;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i += 3) // row 3 will be full of unpassable blocks
            {
                UnpassableBlock currBlock = new UnpassableBlock(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            startRow = 4;
            for (int i = startCol; i < endCol; i++) // row 4 will be full of blocks
            {
                if (i % 4 != 0)
                {
                    Block currBlock = new Block(new MatrixCoords(startRow, i));
                    engine.AddObject(currBlock);
                }
                else
                {
                    // but we will put  an Exploding Block on each 4-th position
                    ExplodingBlock currBlock = new ExplodingBlock(new MatrixCoords(startRow, i));
                    engine.AddObject(currBlock);
                }
            }

            startRow = 6;
            for (int i = startCol; i < endCol; i += 6) // row 6 will have gift blocks on each 6-th position
            {
                GiftBlock currBlock = new GiftBlock(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }
            // Task 5: test TrailObject
            //TrailObject tr = new TrailObject(new MatrixCoords(WorldRows / 2, WorldCols / 2));
            //engine.AddObject(tr);
 
            // Task 7: test MeteoriteBall
            // MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            // Task 9: test Unstoppable Ball and Unpassable Block
            //UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            // adds top row wall (ceiling)
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock wallCell = new IndestructibleBlock(new MatrixCoords(0, i));
                engine.AddObject(wallCell);
            }

            // adds left and right walls)
            for (int i = 1; i < WorldRows; i++)
            {
                IndestructibleBlock wallCell = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(wallCell);
                wallCell = new IndestructibleBlock(new MatrixCoords(i, WorldCols-1));
                engine.AddObject(wallCell);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            // Engine gameEngine = new Engine(renderer, keyboard);
            // Implementing Engine that have shooting capability
            ShootingEngine gameEngine = new ShootingEngine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            // attaches shooting ability as keybord event (using spacebar)
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };
            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
