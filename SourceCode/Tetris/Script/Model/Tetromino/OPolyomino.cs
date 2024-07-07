using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tetris
{
    public class OPolyomino : Tetromino
    {
        public override int Id   => 4;
        public override int Size => 2;

        public override Color Color => FromRGBA(239, 240, 0, 255);

        public override Vector2Int[] State0 { get; } = new Vector2Int[]
            {
                new (0, 0), new(1, 0), new(0, 1), new(1, 1),
            };

        public override Vector2Int[] State1 { get; } = new Vector2Int[]
            {
                new (0, 0), new(1, 0), new(0, 1), new(1, 1),
            };

        public override Vector2Int[] State2 { get; } = new Vector2Int[]
            {
                new (0, 0), new(1, 0), new(0, 1), new(1, 1),
            };

        public override Vector2Int[] State3 { get; } = new Vector2Int[]
            {
                new (0, 0), new(1, 0), new(0, 1), new(1, 1),
            };

        protected override Vector2Int StartOffset { get; } = new Vector2Int(4, 0);
    }
}
