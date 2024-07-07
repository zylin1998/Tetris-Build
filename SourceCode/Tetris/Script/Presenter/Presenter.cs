using Loyufei.DomainEvents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris
{
    public class Presenter : Loyufei.MVP.Presenter
    {
        public Presenter(DomainEventService service) : base(service)
        {

        }

        public override object GroupId => Declarations.Tetris;
    }
}