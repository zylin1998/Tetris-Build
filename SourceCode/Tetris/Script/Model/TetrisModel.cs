using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Loyufei;
using UnityEngine;

namespace Tetris
{
    public class TetrisModel
    {
        public TetrisModel(TetrisGrid grid, GridQuery query, TetrominoMaker maker)
        {
            Grid = grid;
            Maker = maker;
            Query = query;
        }

        
        public TetrisGrid     Grid     { get; }
        public GridQuery      Query    { get; }
        public TetrominoMaker Maker    { get; }
        public bool           GameOver { get; protected set; }
        public bool           CanHold  { get; protected set; } = true;

        public Tetromino Current
        {
            get => Query.Current;

            protected set
            {
                Query.Current = value;

                Current.Reset();

                Query.Distance = GetDistance();
                Query.Next     = Maker.Next;
            }
        }

        public Tetromino Held { get => Query.Hold; set => Query.Hold = value; }
        public Tetromino Next { get => Query.Next; set => Query.Next = value; }

        public void Start() 
        {
            GameOver = false;

            Grid.Clear();

            Current = Maker.GetAndUpdate();
        }

        public void Hold() 
        {
            if (!CanHold) { return; }

            var temp = Held;

            Held    = Current;
            Current = temp ?? Maker.GetAndUpdate();

            CanHold = false;
        }

        public bool RotateCW() 
        {
            Current.RotateCW();

            if (TetrominoFit()) { return true; }

            var range = Current.Size / 2;

            for (int x = -range; x <= range; x++)
            {
                for (int y = 0; y >= -range; y--)
                {
                    if (Move(x, y)) { return true; }
                }
            }

            Current.RotateCCW();

            return false;
        }

        public bool RotateCCW()
        {
            Current.RotateCCW();

            if (TetrominoFit()) { return true; }

            var range = Current.Size / 2;

            for (int x = -range; x <= range; x++)
            {
                for (int y = 0; y >= -range; y--)
                {
                    if (Move(x, y)) { return true; }
                }
            }

            Current.RotateCW();

            return false;
        }

        public bool MoveHorizontal(int direction) 
        {
            return Move(direction, 0);
        }

        public bool MoveVertical(int direction)
        {
            return Move(0, direction);
        }

        public int MoveDown()
        {
            if (!MoveVertical(1)) 
            {
                return PlaceTetromino();
            }
            
            return 0;
        }

        public int Drop() 
        {
            Current.Move(0, Query.Distance);

            return PlaceTetromino();
        }

        #region Private Methods

        private bool Move(int x, int y)
        {
            Current.Move(x, y);

            var fit = TetrominoFit();

            if (!fit) { Current.Move(-x, -y); }

            return fit;
        }

        private bool IsGameOver() 
        {
            return !(Grid.IsRowEmpty(0) && Grid.IsRowEmpty(1));
        }

        private int PlaceTetromino() 
        {
            foreach (var posi in Current.StatePositions()) 
            {
                Grid[posi.x, posi.y].Preserve(1, Current.Color);
            }

            var clear = Grid.ClearFullRows();

            if (IsGameOver()) { GameOver = true; }

            else 
            { 
                Current = Maker.GetAndUpdate();
                CanHold = true;
            }

            return clear;
        }

        private bool TetrominoFit()
        {
            foreach (var p in Current.StatePositions())
            {
                if (!Grid.IsEmpty(p.x, p.y))
                {
                    return false;
                }
            }

            Query.Distance = GetDistance();

            return true;
        }

        private int DropDistance(Vector2Int position) 
        {
            int drop = 0;

            while (Grid.IsEmpty(position.x, position.y + drop + 1)) 
            {
                drop++;
            }

            return drop;
        }

        private int GetDistance() 
        {
            var drop = Declarations.Height;

            foreach (var posi in Current.StatePositions()) 
            {
                drop = Mathf.Min(drop, DropDistance(posi));
            }

            return drop;
        }

        #endregion
    }
}

