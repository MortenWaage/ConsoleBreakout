using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Text;

namespace Codereview
{
    class Game
    {
        private static Game manager = new Game();
        private Game() {}

        public static Game Manager => manager;

        public GameController GameControl { get; set; }
        LevelManager level = new LevelManager();
        Input input = new Input();
        public Input Input => input;
        public LevelManager Level => level;
        public Actor Platform { get; set; }

        public void DuplicateBall(Vector2 position)
        {
            GameControl.DuplicateBall(position);
        }
        public Vector2 PlatformCenter => new Vector2(Platform.Position.X + Platform.Bounds.X * 0.5f, Platform.Position.Y - Data.SizeFromType(Data.Sprites.Ball).Y);
    }
}
