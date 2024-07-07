using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Loyufei;

namespace Tetris
{
    public class Report
    {
        public Report() 
        {
            Reset();
        }

        private int   _Score;
        private int   _Line;
        private int   _Rank;
        private float _Interval;

        public int   Score    => _Score;
        public int   Line     => _Line;
        public int   Rank     => _Rank;
        public float Interval => _Interval;

        public void AddLine(int line) 
        {
            if(line <= 0) { return; }

            _Line += line;

            _Score += 10 * Declarations.LineMultipler[line - 1] * _Rank;

            _Rank = (1 + _Line / Declarations.RankLines).Clamp(1, Declarations.MaxRank);

            _Interval = _Interval * 1f / (1f + 0.05f * _Rank);
        }

        public void Reset() 
        {
            _Score    = 0;
            _Line     = 0;
            _Rank     = 1;
            _Interval = Declarations.UpdateTime;
        }
    }
}
