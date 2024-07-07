using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Loyufei;

namespace Tetris
{
    public class TetrisGrid : EntityForm<DotInfo , DotReposit>
    {
        public TetrisGrid() : base(CreateReposits(Declarations.Width, Declarations.Height))
        {

        }

        public DotReposit this[int row, int column] 
        {
            get => this[row + column * Declarations.Width].To<DotReposit>();
        }

        public bool IsInside(int row, int column) 
        {
            return row.IsClamp(0, Declarations.Width - 1) && column.IsClamp(0, Declarations.Height - 1);
        }

        public bool IsEmpty(int row, int column) 
        {
            return IsInside(row, column) && this[row, column].Data.Block == 0;
        }

        public bool IsRowFull(int row) 
        {
            for(var i = 0; i < Declarations.Width; i++) 
            {
                if (this[i, row].Data.Block == 0) { return false; }
            }

            return true;
        }

        public bool IsRowEmpty(int row)
        {
            for (var i = 0; i < Declarations.Width; i++)
            {
                if (this[i, row].Data.Block != 0) { return false; }
            }

            return true;
        }

        private void ClearRow(int row)
        {
            for (var i = 0; i < Declarations.Width; i++)
            {
                this[i, row].Release();
            }
        }

        private void MoveDown(int row, int move) 
        {
            for (var i = 0; i < Declarations.Width; i++)
            {
                var reposit = this[i, row];

                this[i, row + move].Preserve(reposit);
                
                reposit.Release();
            }
        }

        public int ClearFullRows() 
        {
            int cleared = 0;

            for(int r = Declarations.Height - 1; r >= 0; r--) 
            {
                if (IsRowFull(r)) 
                {
                    ClearRow(r);

                    cleared++;
                }

                else if (cleared > 0) 
                {
                    MoveDown(r, cleared);
                }
            }

            return cleared;
        }

        public void Clear() 
        {
            Dictionary.Values.ForEach(e => e.Data.Clear());
        }

        private static IEnumerable<DotReposit> CreateReposits(int width, int height)
        {
            var list = new List<DotReposit>();

            for (var id = 0; id < width * height; id++) 
            {
                list.Add(new(id));
            }

            return list;
        }
    }

    public class DotReposit : RepositBase<int, DotInfo>
    {
        public DotReposit(int id) : base(id, new())
        {

        }

        public override void Preserve(DotInfo info) 
        {
            Data.Set(info.Block, info.Color);
        }

        public void Preserve(DotReposit dot)
        {
            Preserve(dot.Data);
        }

        public void Preserve(int block, Color color)
        {
            Data.Set(block, color);
        }

        public override void Release()
        {
            Data.Clear();
        }
    }

    public class DotInfo 
    {
        public DotInfo() 
        {
            Clear();
        }

        public DotInfo(int block, Color color)
        {
            Set(block, color);
        }

        public int   Block { get; protected set; }
        public Color Color { get; protected set; }

        public void Set(int block, Color color) 
        {
            Block = block;
            Color = color;
        }

        public void Clear() 
        {
            Block = 0;
            Color = Color.clear;
        }
    }
}
