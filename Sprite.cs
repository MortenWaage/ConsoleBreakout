using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Codereview
{
    public class Sprite
    {
        byte[] texture;
        public Vector2 Size { get; }
        public byte[] Texture => texture;
        public Sprite(Vector2 size, byte[] spriteData)
        {
            Size = size;
            texture = spriteData;
        }
    }
}
