using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;

namespace Codereview
{
    class GameController
    {
        bool _gameOver = false;
        public FrameController Frames { get; private set; }

        public List<IGameLoopObject> objectsToRemove = new List<IGameLoopObject>();
        private List<IGameLoopObject> objectsToAdd = new List<IGameLoopObject>();
        List<IGameLoopObject> gameObjects = new List<IGameLoopObject>();

        private Actor platform { get; set; } = null;

        public GameController() { }

        public void Initialize(float frameRate)
        {
            Game.Manager.GameControl = this;
            Frames = new FrameController(frameRate);
            DrawMapAreaBorder();
        }
        void DrawMapAreaBorder()
        {
            string border = "";
            for (int i = 0; i < Map.MapWidth; i++)
                border += '_';

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, Map.MapHeight);
            Console.WriteLine(border);
        }
        public void GenerateLevel(LevelData.Difficulty difficulty)
        {
            Game.Manager.Level.LoadLevel(difficulty);

            foreach (Brick gameObject in Game.Manager.Level.Bricks)
                if (gameObject != null)
                    gameObjects.Add(gameObject);
        }

        public void PlaceGameObjects()
        {
            Vector2 playerPosition = new Vector2(Map.MapWidth * 0.5f, Map.MapHeight - 2);
            platform = new Actor(Data.Sprites.Platform, playerPosition);

            Vector2 ballPosition = new Vector2(playerPosition.X + platform.Bounds.X * 0.5f -1, playerPosition.Y - Data.SizeFromType(Data.Sprites.Ball).Y);
            gameObjects.Add(new Ball(ballPosition));

            Game.Manager.Platform = platform;
            gameObjects.Add(platform);
        }
        public void MainStart()
        {
            foreach (IGameLoopObject gameObject in gameObjects)
                gameObject.Start();
        }

        //--Main Gameplay Loop
        public void MainUpdate()
        {
            Console.Read();

            while (!_gameOver)
            {
                if (!Frames.OnNextFrame()) continue;
                if (Game.Manager.Level.Bricks.Count <= 0) _gameOver = true;

                SpawnBall();

                UpdateGameObjects();

                GarbageCollection();
            }

            EndGame();
        }

        void EndGame()
        {
            Console.Clear();

            Console.SetCursorPosition((Map.MapWidth / 2) - 3, (Map.MapHeight / 2));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("YOU WON!");


            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Press any key to exit");
            Console.Read();
        }

        void GarbageCollection()
        {
            foreach (var gameObject in objectsToRemove)
                if (gameObjects.Contains(gameObject))
                    gameObjects.Remove(gameObject);

            foreach (var gameObject in objectsToAdd)
                gameObjects.Add(gameObject);

                objectsToRemove.Clear();
                objectsToAdd.Clear();
        }

        public void SpawnBall()
        {
            if (Game.Manager.Input.GetInputShoot())
            {
                Vector2 ballPosition = new Vector2(Game.Manager.Platform.Position.X + platform.Bounds.X * 0.5f, Game.Manager.Platform.Position.Y - Data.SizeFromType(Data.Sprites.Ball).Y);
                gameObjects.Add(new Ball(ballPosition));
            }
        }
        public void DuplicateBall(Vector2 position)
        {
            Vector2 ballPosition = new Vector2(position.X, position.Y);
            var random = new Random();
            var x = random.Next(-1, 1);
            Vector2 ballVelocity = new Vector2(x,1);
            objectsToAdd.Add(new Ball(ballPosition, ballVelocity));
        }

        void UpdateGameObjects()
        {
            foreach (IGameLoopObject gameObject in gameObjects)
                gameObject.Update();
        }
    }
}
