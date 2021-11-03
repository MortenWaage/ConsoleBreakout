using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Codereview
{
    public static class Data
    {
        public enum Sprites 
        { 
            Platform, 
            Ball,
        }

        static readonly Vector2 SizePlatform = new Vector2(14, 1);
        static readonly Vector2 SizeBall = new Vector2(1, 1);
        static readonly Vector2 SizeBrick = new Vector2(4, 1);

        static readonly byte[] Platform =
        {
            2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2,
        };
        static readonly byte[] Ball =
        {
            9,
        };
        static readonly byte[] Brick_1 =
        {
            10, 20, 20, 11,
        };
        static readonly byte[] Brick_2 =
        {
            12, 21, 21, 13,
        };
        static readonly byte[] Brick_3 =
        {
            14, 22, 22, 15,
        };
        static readonly byte[] Brick_4 =
        {
            16, 23, 23, 17,
        };

        public static Vector2 SizeFromType(Sprites type)
        {
            switch (type)
            {
                case Sprites.Platform: return SizePlatform;
                case Sprites.Ball: return SizeBall;
                default: return SizePlatform;
            }
        }

        public static byte[] SpriteFromType(Sprites type)
        {
            switch (type)
            {
                case Sprites.Platform: return Platform;
                case Sprites.Ball: return Ball;
                default: return Platform;
            }
        }

        public static Sprite[] BrickSpritesFromType(int brickType)
        {
            var sprites = new Sprite[brickType];

            if (brickType == 1)
            {
                sprites[0] = new Sprite(SizeBrick, Brick_1);
            }

            if (brickType == 2)
            {
                sprites[0] = new Sprite(SizeBrick, Brick_1);
                sprites[1] = new Sprite(SizeBrick, Brick_2);
            }

            if (brickType == 3)
            {
                sprites[0] = new Sprite(SizeBrick, Brick_1);
                sprites[1] = new Sprite(SizeBrick, Brick_2);
                sprites[2] = new Sprite(SizeBrick, Brick_3);
            }
            if (brickType == 4)
            {
                sprites[0] = new Sprite(SizeBrick, Brick_1);
                sprites[1] = new Sprite(SizeBrick, Brick_2);
                sprites[2] = new Sprite(SizeBrick, Brick_3);
                sprites[3] = new Sprite(SizeBrick, Brick_4);
            }

            return sprites;
        }
    }
}