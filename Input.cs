using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Input;

namespace Codereview
{
    class Input
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);

        private const int KeyPressed = 0x8000;

        internal enum KeyCode : int
        {
            Left = 0x25,
            Up,
            Right,
            Down,
            Space = 0x20,
        }

        static bool IsKeyDown(KeyCode key)
        {
            return (GetKeyState((int)key) & KeyPressed) != 0;
        }

        public Vector2 GetInputDirection()
        {
            Vector2 newPosition = Vector2.Zero;

            if (IsKeyDown((KeyCode.Left)))
                newPosition.X -= 1;

            if (IsKeyDown((KeyCode.Right)))
                newPosition.X += 1;

            return newPosition;
        }

        public bool GetInputShoot()
        {
            if (IsKeyDown((KeyCode.Space)))
                return true;

            return false;
        }
    }
}
