using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Tetris
{
    public class PlayerInput
    {
        public virtual bool Spin      => Input.GetKeyDown(KeyCode.UpArrow);
        public virtual bool Left      => Input.GetKeyDown(KeyCode.LeftArrow);
        public virtual bool Right     => Input.GetKeyDown(KeyCode.RightArrow);
        public virtual bool SprintOn  => Input.GetKeyDown(KeyCode.DownArrow);
        public virtual bool SprintOff => Input.GetKeyUp(KeyCode.DownArrow);
        public virtual bool Hold      => Input.GetKeyUp(KeyCode.C);
        public virtual bool Drop      => Input.GetKeyUp(KeyCode.Space);
    }
}
