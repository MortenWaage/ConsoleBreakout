using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace Codereview
{
    class Ball : IGameLoopObject
    {
        bool _isDestroyed = false;
        private Vector2 _velocity;
        private float _speed = 1f;

        Vector2 Position;
        Vector2 Bounds;
        Sprite Sprite;

        public Ball(Vector2 position)
        {
            Position = position;
            Sprite = new Sprite(Data.SizeFromType(Data.Sprites.Ball), Data.SpriteFromType(Data.Sprites.Ball));
            _velocity = new Vector2(0, -1) * _speed;

            Vector2 extents;
            extents.X = Sprite.Size.X;
            extents.Y = Sprite.Size.Y;
            Bounds = new Vector2(extents.X, extents.Y);
        }
        public Ball(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Sprite = new Sprite(Data.SizeFromType(Data.Sprites.Ball), Data.SpriteFromType(Data.Sprites.Ball));
            _velocity = velocity * _speed;

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
            _velocity = UpdateVelocity();

            var destination = Position + _velocity;
            MoveTo(destination);
        }

        Vector2 UpdateVelocity()
        {
            bool hasCollision;
            Vector2 newVelocity;

            newVelocity = CollidedWithWall(out hasCollision);
            if (hasCollision) return newVelocity;

            newVelocity = CollidedWithBrick(out hasCollision);
            if (hasCollision) return newVelocity;

            newVelocity = CollidedWithPlayer(out hasCollision);
            if (hasCollision) return newVelocity;

            return _velocity;
        }

        Vector2 CollidedWithWall(out bool collided)
        {
            Vector2 newVelocity;
            bool hitBottom;

            if (Map.CollidedWithWall(Position, _velocity, Bounds, out newVelocity, out hitBottom))
            {
                if (hitBottom)
                {
                    DestroyBall();
                    collided = true;
                    return newVelocity;
                }
                collided = true;
                return newVelocity;
            }

            collided = false;
            return Vector2.Zero;
        }

        void DestroyBall()
        {
            _isDestroyed = true;
            Renderer.Clear(Position, Bounds);
            Game.Manager.GameControl.objectsToRemove.Add(this);
        }

        Vector2 CollidedWithBrick(out bool collided)
        {
            Vector2 newVelocity;
            Brick brick = null;
            collided = false;

            if (Map.IntersectsWithBricks(Position, _velocity, out newVelocity, out brick))
            {
                if (brick == null) return Vector2.Zero;

                Collide(brick);
                collided = true;
                return newVelocity;
            }

            return Vector2.Zero;

            void Collide(Brick brick)
            {
                //--Delete the brick
                brick.Hit();
            }
        }

        Vector2 CollidedWithPlayer(out bool collided)
        {
            var destination = Position + _velocity;
            var pStart = (int)Game.Manager.Platform.Position.X;
            var pEnd = pStart + (int)Game.Manager.Platform.Bounds.X;
            var pY = (int)Game.Manager.Platform.Position.Y;

            collided = false;
            if ((int)destination.Y != pY) return Vector2.Zero;
            if ((int)destination.X < pStart) return Vector2.Zero;
            if ((int)destination.X > pEnd) return Vector2.Zero;

            collided = true;
            if ((int)destination.X < (int)Game.Manager.PlatformCenter.X) return new Vector2(-1, -_velocity.Y);
            if ((int)destination.X > (int)Game.Manager.PlatformCenter.X) return new Vector2(1, -_velocity.Y);
            return new Vector2(_velocity.X, -_velocity.Y);
        }

        void MoveTo(Vector2 destination)
        {
            if (_isDestroyed) return;

            Renderer.Clear(Position, Bounds);
            Position = destination;
            Renderer.Draw(Sprite, Position, Bounds);
        }
    }
}