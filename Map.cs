using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Codereview
{
    public static class Map
    {
        
        public static readonly int MapWidth = 120;
        public static readonly int MapHeight = 32;
        public static readonly int InfoArea = 6;
        public static readonly int InfoAreaStart = MapHeight + 2;
        public static readonly int MapTotalHeight = 240;
        public static readonly int BrickWidth = 3;
        public static readonly int BrickHeight = 1;
        public static readonly int BrickSpaceX = 3;
        public static readonly int BrickSpaceY = 2;

        public static bool OutOfBounds(Vector2 position, Vector2 bounds)
        {
            float left = position.X;
            float right = position.X + bounds.X;
            float top = position.Y;
            float bottom = position.Y + bounds.Y;
            
            Debugging.DisplayBoundsCheck(left, right, top, bottom);

            if (left <= 0 || right >= MapWidth || top <= 0 || bottom >= MapHeight)
                return true;
                
            return false;
        }

        public static bool CollidedWithWall(Vector2 position, Vector2 velocity, Vector2 bounds, out Vector2 newVelocity, out bool hitBottom)
        {
            Vector2 destination = position + velocity;

            float left = destination.X;
            float right = destination.X + bounds.X;
            float top = destination.Y;
            float bottom = destination.Y + bounds.Y;

            if (left <= 0 || right >= MapWidth)
            {
                newVelocity = new Vector2(-velocity.X, velocity.Y);
                hitBottom = false;
                return true;
            }
            if (top <= 0)
            {
                newVelocity = new Vector2(velocity.X, -velocity.Y);
                hitBottom = false;
                return true;
            }
            if (bottom >= MapHeight)
            {
                newVelocity = new Vector2(0, -1);
                hitBottom = true;
                return true;
            }

            hitBottom = false;

            newVelocity = velocity;
            hitBottom = false;
            return false;
        }

        public static bool IntersectsWithBricks(Vector2 position, Vector2 velocity, out Vector2 newVelocity, out Brick _brick)
        {
            Vector2 destination = position + velocity;
            Vector2 invertedVelocity;

            //--Out
            newVelocity = Vector2.Zero;
            _brick = null;

            foreach (Brick brick in Game.Manager.Level.Bricks)
                if (CollidedWithBrick(destination, brick))
                {
                    newVelocity = invertedVelocity;
                    _brick = brick;
                    return true;
                }

            return false;

            bool CollidedWithBrick(Vector2 destination, Brick brick)
            {
                float pointX = destination.X;
                float pointY = destination.Y;

                //Debugging.DisplayCollisions(destination, brick.Position);

                Vector2 bPos = brick.Position;
                Vector2 bBounds = brick.Bounds;
                
                float bLeft = bPos.X;
                float bRight = bPos.X + bBounds.X;
                float bTop = bPos.Y;
                float bBottom = bPos.Y + bBounds.Y;

                invertedVelocity = velocity;

                //--Check if ball intersects with the brick
                bool intersects = (pointX < bLeft || pointX > bRight ||
                                   pointY < bTop || pointY > bBottom);

                //--Check if  ball is above/below or left/right of brick to determine new direction
                var previousPosition = destination - velocity;
                if ((int)previousPosition.X >= (int)bPos.X && (int)previousPosition.X <= bRight) invertedVelocity = new Vector2(velocity.X, -velocity.Y);
                if ((int)previousPosition.Y == (int)bPos.Y) invertedVelocity = new Vector2(-velocity.X, velocity.Y);

                return !intersects;
            }
        }
    }
}
