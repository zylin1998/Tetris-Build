using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tetris
{
    public class TPolyomino : Tetromino
    {
        public override int Id => 6;

        public override Color Color => FromRGBA(159, 0, 242, 255);

        public override Vector2Int[] State0 { get; } = new Vector2Int[]
            {
                new(1, 0), new(0, 1), new(1, 1), new(2, 1)
            };

        public override Vector2Int[] State1 { get; } = new Vector2Int[]
            {
                new(1, 0), new(1, 1), new(2, 1), new(1, 2)
            };

        public override Vector2Int[] State2 { get; } = new Vector2Int[]
            {
                new(0, 1), new(1,1), new(2, 1), new(1, 2)
            };

        public override Vector2Int[] State3 { get; } = new Vector2Int[]
            {
                new(1, 0), new(0, 1), new(1, 1), new(1, 2)
            };

        protected override Vector2Int StartOffset { get; } = new Vector2Int(3, 0);
    }
}
