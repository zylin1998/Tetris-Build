using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Loyufei;

namespace Tetris
{
    public class GridQuery
    {
        public GridQuery(TetrisGrid grid) 
        {
            Grid = grid;
        }

        public TetrisGrid Grid { get; }

        public int Distance { get; set; }

        public Tetromino Next    { get; set; }
        public Tetromino Hold    { get; set; }  
        public Tetromino Current { get; set; }

        public Dictionary<object, Color> Drawing 
        {
            get 
            {
                var dic   = new Dictionary<object, Color>();
                var color = Current.Color;
                var alpha = new Color(color.r, color.g, color.b, 0.5f);
                var width = Declarations.Width;

                foreach (var dot in Grid)
                {
                    if (dot.Data.Block >= 1) { dic.Add(dot.Identity, dot.Data.Color); }
                }

                foreach(var posi in Current.StatePositions()) 
                {
                    dic.GetorAdd(posi.x + posi.y * width, () => color);
                }

                foreach (var posi in Current.StatePositions())
                {
                    dic.GetorAdd(posi.x + (posi.y + Distance) * width, () => alpha);
                }

                return dic;
            }
        }
    }
}
