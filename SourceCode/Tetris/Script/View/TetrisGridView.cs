using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Loyufei;
using Loyufei.ViewManagement;

namespace Tetris
{
    public class TetrisGridView : MenuBase
    {
        [SerializeField]
        private Transform _Content;

        [Inject]
        private void Constrtuct(Dot.Pool pool) 
        {
            var list = new List<Dot>();

            for(int id = 0; id < Declarations.Width * Declarations.Height; id++) 
            {
                list.Add(pool.Spawn(id, _Content));
            }

            Dots = list;
        }

        public IEnumerable<Dot> Dots { get; protected set; }
    }
}