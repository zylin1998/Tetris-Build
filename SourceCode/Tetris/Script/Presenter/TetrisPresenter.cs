using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Loyufei;
using Loyufei.DomainEvents;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

namespace Tetris
{
    public class TetrisPresenter : Presenter
    {
        public TetrisPresenter(TetrisModel model, Report report, DomainEventService service) : base(service)
        {
            Model  = model;
            Report = report;
        }

        public TetrisModel Model  { get; }
        public Report      Report { get; }

        private bool          _Sprint   = false;

        private GameOver      GameOver { get; } = new GameOver();
        private UpdateMonitor Update   { get; } = new();

        protected override void RegisterEvents()
        {
            DomainEventService.Register<RotateCW>      (Rotate, GroupId);
            DomainEventService.Register<RotateCCW>     (Rotate, GroupId);
            DomainEventService.Register<MoveHorizontal>(  Move, GroupId);
            DomainEventService.Register<StartTetris>   ( Start, GroupId);
            DomainEventService.Register<HoldTetromino> (  Hold, GroupId);
            DomainEventService.Register<DropTetromino> (  Drop, GroupId);
            DomainEventService.Register<SetSprint>     (Sprint, GroupId);
        }

        public void Hold(HoldTetromino hold) 
        {
            Model.Hold();

            SettleEvents(Update);
        }

        public void Drop(DropTetromino drop) 
        {
            Report.AddLine(Model.Drop());

            SettleEvents(Update);
        }

        public void Rotate(RotateCW  rotate) 
        {
            var r = Model.RotateCW();
            
            if (r) { SettleEvents(Update); }
        }

        public void Rotate(RotateCCW rotate)
        {
            var r = Model.RotateCCW();

            if (r) { SettleEvents(Update); }
        }

        public void Move(MoveHorizontal move)
        {
            if (Model.MoveHorizontal(move.Direction)) { SettleEvents(Update); };
        }

        public void Sprint(SetSprint sprint) 
        {
            _Sprint = sprint.Sprint;
        }

        public void Start(StartTetris start)
        {
            EventSystem.current.StartCoroutine(GameLoop());
        }

        public IEnumerator GameLoop() 
        {
            Model.Start();

            Report.Reset();

            SettleEvents(Update);

            for (; !Model.GameOver;)
            {
                yield return new WaitForSeconds(Report.Interval * (_Sprint ? 0.1f : 1f));

                Report.AddLine(Model.MoveDown());

                SettleEvents(Update);
            }

            SettleEvents(GameOver);
        }
    }

    public class RotateCW : DomainEventBase 
    {

    }

    public class RotateCCW : DomainEventBase
    {

    }

    public class MoveHorizontal : DomainEventBase 
    {
        public MoveHorizontal(int direction) 
        {
            Direction = direction;
        }

        public int Direction { get; }
    }

    public class HoldTetromino : DomainEventBase 
    {

    }

    public class DropTetromino : DomainEventBase
    {

    }

    public class SetSprint : DomainEventBase 
    {
        public SetSprint(bool sprint)
        {
            Sprint = sprint;
        }

        public bool Sprint { get; }
    }

    public class StartTetris : DomainEventBase 
    {

    }

    public class GameOver : DomainEventBase 
    {

    }

    public class UpdateMonitor : DomainEventBase
    {
        public UpdateMonitor() 
        {
            
        }
    }
}