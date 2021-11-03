using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Codereview
{
    public class Brick : IGameLoopObject
    {
        int _durability;
        public Vector2 Position;
        public Vector2 Bounds;
        Sprite[] Sprites;
        Sprite Sprite;

        public Brick(Vector2 position, Sprite[] sprites)
        {
            Position = position;
            _durability = sprites.Length-1;
            Sprites = sprites;
            Sprite = sprites[_durability];
            

            Vector2 extents;
            extents.X = Sprite.Size.X;
            extents.Y = Sprite.Size.Y;
            Bounds = new Vector2(extents.X, extents.Y);
        }

        public void Start()
        {
            Renderer.Draw(Sprite, Position, Bounds);
        }

        public void Update()
        {

        }

        public void Hit()
        {
            _durability -= 1;

            if (_durability < 0)
            {
                Renderer.Clear(Position, Bounds);
                Game.Manager.Level.Bricks.Remove(this);
                Game.Manager.DuplicateBall(Position);
            }
            else
            {
                Sprite = Sprites[_durability];
                Renderer.Draw(Sprite, Position, Bounds);
            }
        }
    }
}
