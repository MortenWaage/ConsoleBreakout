using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Codereview
{
    class LevelManager
    {
        byte[] mapData;
        List<Brick> _bricks;

        public List<Brick> Bricks => _bricks;

        public void LoadLevel(LevelData.Difficulty difficulty)
        {
            mapData = LevelData.LoadLevel(difficulty);
            int width = LevelData.LevelWidth(difficulty);
            int height = LevelData.LevelHeight(difficulty);
            _bricks = new List<Brick>();

            GenerateBricks(width, height);
        }

        void GenerateBricks(int width, int height)
        {
            Vector2 mapDrawStart;
            mapDrawStart.X = Map.MapWidth * 0.5f - ((Map.BrickWidth + Map.BrickSpaceX) * width * 0.5f);
            mapDrawStart.Y = 2;

            for (int i = 0, y = 0; y < height; y++)
                for (int x = 0; x < width; x++, i++)
                    GenerateBrick(i, x, y);

            void GenerateBrick(int i, int x, int y)
            {
                byte brickType = mapData[i];
                if (brickType != 0) _bricks.Add(BrickFromType(brickType, x, y, mapDrawStart));
            }
        }
        Brick BrickFromType(int brickType, int x, int y, Vector2 mapDrawStart)
        {
            Vector2 position = new Vector2(mapDrawStart.X + x * (Map.BrickWidth + Map.BrickSpaceX), mapDrawStart.Y + y * (Map.BrickHeight + Map.BrickSpaceY));
            Sprite[] sprites = Data.BrickSpritesFromType(brickType);
            return new Brick(position, sprites);
        }
    }
}
