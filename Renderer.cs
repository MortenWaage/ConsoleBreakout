using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Codereview
{
    public static class Renderer
    {
        public static void Clear(Vector2 position, Vector2 bounds)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;

            int pivotX = (int)position.X;
            int pivotY = (int)position.Y;
            int width = (int)bounds.X;
            int height = (int)bounds.Y;

            for (int i = 0, y = 0; y < height; y++)
            for (int x = 0; x < width; x++, i++)
                ClearPixel(x, y);

            void ClearPixel(int x, int y)
            {
                Console.SetCursorPosition(pivotX + x, pivotY + y);
                Console.WriteLine(' ');
            }
        }

        public static void Draw(Sprite sprite, Vector2 position, Vector2 bounds)
        {
            int pivotX = (int)Math.Floor(position.X);
            int pivotY = (int)Math.Floor(position.Y);
            int width = (int)bounds.X;
            int height = (int)bounds.Y;

            for (int i = 0, y = 0; y < height; y++)
                for (int x = 0; x < width; x++, i++)
                    DrawPixel(i, x, y);

            void DrawPixel(int i, int x, int y)
            {
                byte pixel = sprite.Texture[i];

                char newChar;

                switch (pixel)
                {
                    default: newChar = None(); break;
                    case (byte)0: newChar = None(); break;
                    case (byte)1: newChar = Platform(); break;
                    case (byte)2: newChar = PlatformEnd(); break;
                    //--Brick End Pieces
                    //--Left
                    case (byte)10: newChar = Brick_End_1(0); break;
                    case (byte)12: newChar = Brick_End_2(0); break;
                    case (byte)14: newChar = Brick_End_3(0); break;
                    case (byte)16: newChar = Brick_End_4(0); break;
                    //--Right
                    case (byte)11: newChar = Brick_End_1(1); break;
                    case (byte)13: newChar = Brick_End_2(1); break;
                    case (byte)15: newChar = Brick_End_3(1); break;
                    case (byte)17: newChar = Brick_End_4(1); break;

                    //--Brick Mid Pieces
                    case (byte)20: newChar = Brick_Mid_1(); break;
                    case (byte)21: newChar = Brick_Mid_2(); break;
                    case (byte)22: newChar = Brick_Mid_3(); break;
                    case (byte)23: newChar = Brick_Mid_4(); break;
                    //--Ball Pieces
                    case (byte)9: newChar = Ball_1(); break;
                }
                Console.SetCursorPosition(pivotX + x, pivotY + y);
                Console.WriteLine(newChar);
            }
        }
        static char PlatformEnd()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            return '^';
        }
        static char Platform()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            return (char)183;
        }
        static char None()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            return ' ';
        }
        static char Ball_1()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            return 'O';
        }
        //--Brick End
        static char Brick_End_1(byte leftRight)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            
            if (leftRight == 0) return '[';
            return ']';
        }
        static char Brick_End_2(byte leftRight)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            
            if (leftRight == 0) return '[';
            return ']';
        }
        static char Brick_End_3(byte leftRight)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            if (leftRight == 0) return '[';
            return ']';
        }
        static char Brick_End_4(byte leftRight)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkRed;

            if (leftRight == 0) return '[';
            return ']';
        }
        //--Brick Mid
        private static byte test = 131;
        static char Brick_Mid_1()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            return (char)test;
        }
        static char Brick_Mid_2()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            return (char)(test+1);
        }
        static char Brick_Mid_3()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            return (char)(test+2);
        }
        static char Brick_Mid_4()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            return (char)(test + 2);
        }
    }
}
