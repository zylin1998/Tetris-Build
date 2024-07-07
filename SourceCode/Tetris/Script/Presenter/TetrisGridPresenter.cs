using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Loyufei.DomainEvents;

namespace Tetris
{
    public class TetrisGridPresenter : Presenter
    {
        public TetrisGridPresenter(TetrisGridView view, GridQuery query, DomainEventService service) : base(service)
        {
            View  = view;
            Query = query;
        }

        public TetrisGridView View  { get; }
        public GridQuery      Query { get; }

        protected override void RegisterEvents()
        {
            DomainEventService.Register<UpdateMonitor>(Update, GroupId);
        }

        public void Update(UpdateMonitor update) 
        {
            var dic = Query.Drawing;

            foreach (var dot in View.Dots)
            {
                var blocked = dic.TryGetValue(dot.Id, out var color);

                if (blocked) { dot.SetDot(color); }

                else { dot.Clear(); }
            }
        }
    }
}