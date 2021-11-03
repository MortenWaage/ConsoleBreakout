using System;
using System.Collections.Generic;
using System.Text;

namespace Codereview
{
    public static class LevelData
    {
        public enum Difficulty { Easy, Medium, Hard, Test, Casual }

        public static byte[] LoadLevel(Difficulty difficulty)
        {
            return Levels[difficulty];
        }

        private static readonly Dictionary<Difficulty, byte[]> Levels = new Dictionary<Difficulty, byte[]>()
        {
            {Difficulty.Easy, new byte[]
                {
                    3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                    3, 2, 2, 2, 2, 2, 2, 2, 2, 3,
                    3, 2, 1, 1, 1, 1, 1, 1, 2, 3,
                    3, 2, 1, 1, 1, 1, 1, 1, 2, 3,
                    3, 2, 1, 1, 1, 1, 1, 1, 2, 3,
                    3, 2, 2, 2, 2, 2, 2, 2, 2, 3,
                    3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                }
            },
            {Difficulty.Medium, new byte[]
                {
                    3, 3, 1, 1, 0, 0, 1, 1, 3, 3,
                    3, 2, 0, 1, 1, 1, 1, 0, 2, 3,
                    0, 0, 2, 1, 2, 2, 1, 2, 0, 0,
                    2, 2, 2, 2, 3, 3, 2, 2, 2, 2,
                    0, 0, 1, 1, 2, 2, 1, 1, 0, 0,
                    3, 2, 0, 0, 1, 1, 0, 0, 2, 3,
                    3, 3, 1, 1, 0, 0, 1, 1, 3, 3,
                }
            },
            {Difficulty.Hard, new byte[]
                {
                    3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                    3, 0, 0, 0, 3, 3, 0, 0, 0, 3,
                    3, 1, 2, 1, 2, 2, 1, 2, 0, 3,
                    3, 0, 2, 1, 4, 4, 1, 3, 0, 3,
                    3, 0, 2, 1, 2, 2, 1, 3, 0, 3,
                    3, 0, 0, 0, 3, 3, 0, 0, 0, 3,
                    3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                }
            },
            {Difficulty.Test, new byte[]
                {
                    1,
                }
            },
            {Difficulty.Casual, new byte[]
                {
                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                    1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                    2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
                    3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
                    4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
                }
            },
        };

        public static int LevelWidth(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy   => 10,
                Difficulty.Medium => 10,
                Difficulty.Hard   => 10,
                Difficulty.Test   => 1,
                Difficulty.Casual => 18,
                _ => 0
            };
        }
        public static int LevelHeight(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy   => 7,
                Difficulty.Medium => 7,
                Difficulty.Hard   => 7,
                Difficulty.Test   => 1,
                Difficulty.Casual => 6,
                _ => 0
            };
        }
    }
}
