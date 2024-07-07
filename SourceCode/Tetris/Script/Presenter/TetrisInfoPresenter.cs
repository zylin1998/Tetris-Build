using Loyufei.DomainEvents;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tetris
{
    public class TetrisInfoPresenter : Presenter
    {
        public TetrisInfoPresenter(GridQuery query, Report report, TetrisInfoView view, DomainEventService service) : base(service)
        {
            Query  = query;
            View   = view;
            Report = report;
            
            Init();
        }

        public Report         Report { get; }
        public GridQuery      Query  { get; }
        public TetrisInfoView View   { get; }

        protected override void RegisterEvents()
        {
            DomainEventService.Register<UpdateMonitor>(Update  , GroupId);
            DomainEventService.Register<GameOver>     (GameOver, GroupId);
        }

        public void Update(UpdateMonitor monitor) 
        {
            View.SetNext (Query .Next);
            View.SetHold (Query .Hold);
            View.SetScore(Report.Score);
            View.SetLine (Report.Line);
        }

        private void Init() 
        {
            View.SetNext(null);
            View.SetHold(null);
            View.SetScore(0);
            View.SetLine (0);

            var buttons = View.OfType<ButtonListener>().ToDictionary(k => k.Id);
            var start   = buttons[0];
            var quit    = buttons[1];
            
            start.AddListener((id) =>
            {
                View.GameOver(false);

                SettleEvents(new StartTetris());
            });
            quit.AddListener((id) => Application.Quit());
        }

        private void GameOver(GameOver gameOver) 
        {
            View.GameOver(true);
        }
    }
}