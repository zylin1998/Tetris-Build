using Loyufei.DomainEvents;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Tetris
{
    public class PlayerPresenter : Presenter
    {
        public PlayerPresenter(PlayerInput input, DomainEventService service) : base(service)
        {
            Input = input;
        }

        public PlayerInput Input { get; }

        private bool _Tick;

        public void Start(StartTetris start) 
        {
            _Tick = true;

            Observable
                .EveryUpdate()
                .TakeWhile(num => _Tick)
                .Subscribe(num => GetInput());
        }

        private void Over(GameOver gameOver) 
        {
            _Tick = false;
        }

        protected override void RegisterEvents()
        {
            DomainEventService.Register<StartTetris>(Start, GroupId);
            DomainEventService.Register<GameOver>   ( Over, GroupId);
        }

        public void GetInput() 
        {
            if (Input.Left     ) { SettleEvents(new MoveHorizontal(-1)); }
            if (Input.Right    ) { SettleEvents(new MoveHorizontal( 1)); }
            if (Input.Spin     ) { SettleEvents(new RotateCW()); }
            if (Input.SprintOn ) { SettleEvents(new SetSprint(true)); }
            if (Input.SprintOff) { SettleEvents(new SetSprint(false)); }
            if (Input.Hold)      { SettleEvents(new HoldTetromino()); }
            if (Input.Drop)      { SettleEvents(new DropTetromino()); }
        }
    }
}