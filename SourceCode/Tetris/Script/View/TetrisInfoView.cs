using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Loyufei.ViewManagement;
using Zenject;
using System.Linq;

namespace Tetris
{
    public class TetrisInfoView : MenuBase
    {
        [SerializeField]
        private TetrominoDisplay _Next;
        [SerializeField]
        private TetrominoDisplay _Hold;
        [SerializeField]
        private TextMeshProUGUI  _Score;
        [SerializeField]
        private TextMeshProUGUI  _Line;
        [SerializeField]
        private Transform _GameOver;

        private ButtonListener _Start;

        protected override void Awake()
        {
            base.Awake();

            SetScore(0);
            SetLine(0);

            _Start = GetComponentsInChildren<ButtonListener>()
                .FirstOrDefault(b => b.Id == 0);
        }

        public void SetScore(int score) 
        {
            _Score.SetText(score.ToString());
        }

        public void SetLine (int line)
        {
            _Line.SetText (line.ToString());
        }

        public void SetNext(Tetromino tetromino) 
        {
            _Next.Set(tetromino);
        }

        public void SetHold(Tetromino tetromino)
        {
            _Hold.Set(tetromino);
        }

        public void GameOver(bool over) 
        {
            _Start.Listener.interactable = over;
            
            _GameOver.gameObject.SetActive(over);
        }

        [Inject]
        private void Construct(IEnumerable<TetrominoDisplay> displays) { }
    }
}