using System;
using System.Numerics;

namespace Codereview
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Console.SetBufferSize(Map.MapWidth + 20, Map.MapTotalHeight + 20);
            Console.WindowWidth = Map.MapWidth;
            Console.WindowHeight = Map.MapHeight + Map.InfoArea + 1;

            var game = new GameController();

            game.Initialize(50);
            game.GenerateLevel(LevelData.Difficulty.Medium);
            game.PlaceGameObjects();
            game.MainStart();
            game.MainUpdate();
        }
    }
}
