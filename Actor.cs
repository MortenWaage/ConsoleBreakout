using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Codereview
{
    public class Actor : IGameLoopObject
    {
        public Sprite Sprite { get; }
        public Vector2 Position { get; set; }
        public Vector2 Bounds;
        private float speed = 4;

        public Actor(Data.Sprites type, Vector2 position)
        {
            Sprite = new Sprite(Data.SizeFromType(type), Data.SpriteFromType(type));
            Position = position;

            Vector2 extents;
            extents.X = Sprite.Size.X;
            extents.Y = Sprite.Size.Y;
            Bounds = new Vector2(extents.X, extents.Y);

            //--Force Renderer to Draw sprite at game start
            MoveTo(Position);
        }

        public void Start()
        {

        }

        public void Update()
        {
            MovePlatform();
        }

        void MovePlatform()
        {
            Vector2 inputDirection = Game.Manager.Input.GetInputDirection();
            Vector2 destination = Position + inputDirection * speed;

            Debugging.DisplayMovement(inputDirection, Position, Bounds);

            if (inputDirection != Vector2.Zero)
            {
                bool outOfBounds = Map.OutOfBounds(destination, Bounds);
                if (!outOfBounds) MoveTo(destination);

                Debugging.DisplayBoundsInfo(outOfBounds, destination);
            }
        }

        void MoveTo(Vector2 destination)
        {
            Renderer.Clear(Position, Bounds);
            Position = destination;
            Renderer.Draw(Sprite, Position, Bounds);
        }
    }
}
