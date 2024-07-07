using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Tetris
{
    public class TetrominoMaker
    {
        public TetrominoMaker() 
        {
            Next = RandonTetromino();
        }

        public Tetromino[] Tetrominos { get; } = new Tetromino[]
            {
                new IPolyomino(),
                new JPolyomino(),
                new LPolyomino(),
                new OPolyomino(),
                new SPolyomino(),
                new TPolyomino(),
                new ZPolyomino(),
            };

        public Tetromino Next { get; protected set; }

        public Tetromino RandonTetromino() 
        {
            var random = UnityEngine.Random.Range(0, Tetrominos.Length);

            return Tetrominos[random];
        }

        public Tetromino GetAndUpdate() 
        {
            var tetromino = Next;

            do
            {
                Next = RandonTetromino();
            }
            while (tetromino.Id == Next.Id);

            return tetromino;
        }
    }
}
