using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Tetris
{
    public static class Declarations
    {
        public const string Tetris        = "Tetris";

        public static int    Width      => 10;
        public static int    Height     => 20;
        public static float  UpdateTime => 0.8f;
        public static int    RankLines  => 10;
        public static int    MaxRank    => 15;

        public static int[]  LineMultipler => new int[] { 1, 2, 10, 20 };
    }
}
