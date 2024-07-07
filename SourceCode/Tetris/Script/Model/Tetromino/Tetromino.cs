using Loyufei;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Tetris
{
    public class Tetromino
    {
        public class Pool : MemoryPool<Tetromino> 
        {
            
        }

        public Tetromino()
        {
            States = new Vector2Int[][] { State0, State1, State2, State3 };

            Offset = StartOffset;
        }

        public virtual Color Color { get; } = Color.blue;

        public virtual int          Id     { get; }
        public virtual int          Size   { get; } = 3;
        public virtual Vector2Int[] State0 { get; }
        public virtual Vector2Int[] State1 { get; }
        public virtual Vector2Int[] State2 { get; }
        public virtual Vector2Int[] State3 { get; }

        protected virtual Vector2Int StartOffset { get; }

        protected Vector2Int[][] States { get; }

        private int        _State;

        public Vector2Int Offset { get; protected set; }

        public IEnumerable<Vector2Int> StatePositions() 
        {
            foreach(var posi in States[_State]) 
            {
                yield return new Vector2Int(posi.x + Offset.x, posi.y + Offset.y);
            }
        }

        public void RotateCW() 
        {
            _State = (_State + 1) % States.Length;
        }

        public void RotateCCW() 
        {
            _State = _State == 0 ? States.Length - 1 : _State + 1;
        }

        public void Move(int row, int col) 
        {
            Offset += new Vector2Int(row, col);
        }

        public void Reset() 
        {
            _State = 0;

            Offset = StartOffset;
        }

        protected static Color FromRGBA(float r, float g, float b, float a) 
        {
            return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }
    }
}