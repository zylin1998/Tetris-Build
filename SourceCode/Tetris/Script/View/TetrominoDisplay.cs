using Loyufei;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Tetris
{
    public class TetrominoDisplay : MonoBehaviour
    {
        [SerializeField]
        private Transform _Content;

        private List<Dot> _Dots;

        [Inject]
        private void Construct(Dot.Pool pool)
        {
            _Dots = new List<Dot>();

            for(int id = 0; id < 16; id++) 
            {
                _Dots.Add(pool.Spawn(id, _Content));
            }
        }

        public void Set(Tetromino tetromino) 
        {
            if (tetromino.IsDefault()) 
            {
                _Dots.ForEach(dot => dot.Clear());

                return;
            }

            var delta = (4 - tetromino.Size) > 0 ? 1 : 0;
            var state = tetromino.State0.Select(p => p.x + delta + (p.y + delta) * 4);

            foreach (var dot in _Dots)
            {
                if (state.Any(posi => posi == dot.Id))
                {
                    dot.SetDot(tetromino.Color);
                }

                else { dot.Clear(); }
            }
        }

        public void Clear()
        {
            foreach (var dot in _Dots)
            {
                dot.Clear();
            }
        }
    }
}