using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Codereview
{
    public static class Debugging
    {
        public static void DisplayMovement(Vector2 inputDirection, Vector2 position, Vector2 bounds)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, Map.InfoAreaStart);
            Console.WriteLine($"Input Direction {inputDirection}");
            Console.WriteLine($"Position: {position}");
            Console.WriteLine($"Bounds: {bounds}");
        }

        public static void DisplayBoundsInfo(bool outOfBounds, Vector2 destination)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(30, Map.InfoAreaStart);
            Console.WriteLine($"Out of bounds: {outOfBounds}");
            Console.SetCursorPosition(30, Map.InfoAreaStart + 1);
            Console.WriteLine($"Next position: {destination}");
        }

        public static void DisplayBoundsCheck(float left, float right, float top, float bottom)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(30, Map.InfoAreaStart + 2);
            Console.WriteLine("Left, Right, Top, Bottom");
            Console.SetCursorPosition(30, Map.InfoAreaStart + 3);
            Console.WriteLine($"{left},{right},{top},{bottom}");
        }

        public static void DisplayCollisions(Vector2 destination, Vector2 brickPosition)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(70, Map.InfoAreaStart + 2);
            Console.WriteLine("Ball Position, Brick Position");
            Console.SetCursorPosition(70, Map.InfoAreaStart + 3);
            Console.WriteLine($"{destination},{brickPosition}");
        }

        public static void DisplayDeltaTime(double timeSinceLastFrame)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(70, Map.InfoAreaStart + 2);
            Console.WriteLine($"Current DeltaTime: {timeSinceLastFrame}");
        }
    }
}
