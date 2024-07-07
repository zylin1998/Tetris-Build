using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tetris
{
    public class IPolyomino : Tetromino
    {
        public override int Id   => 1;
        public override int Size => 4;

        public override Color Color => FromRGBA(0, 240, 239, 255); 

        public override Vector2Int[] State0 { get; } = new Vector2Int[]
            {
                new(0, 1), new(1,1), new(2,1), new(3,1)
            };

        public override Vector2Int[] State1 { get; } = new Vector2Int[]
            {
                new(2, 0), new(2,1), new(2,2), new(2,3)
            };

        public override Vector2Int[] State2 { get; } = new Vector2Int[]
            {
                new(0, 2), new(1,2), new(2,2), new(3,2)
            };

        public override Vector2Int[] State3 { get; } = new Vector2Int[]
            {
                new(1, 0), new(1,1), new(1,2), new(1,3)
            };

        protected override Vector2Int StartOffset { get; } = new Vector2Int(3, 0);
    }
}
