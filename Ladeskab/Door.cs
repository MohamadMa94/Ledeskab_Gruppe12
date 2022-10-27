using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class Door : IDoor
    {
        public bool IsLocked { get; private set; } = false;
        public event EventHandler<DoorEventArgs> DoorEvent;
        protected virtual void DoorChanged(DoorEventArgs e)
        {
            DoorEvent?.Invoke(this, e);
        }
        void IDoor.DoorClosed()
        {
            DoorChanged(new DoorEventArgs { IsOpen = false });

        }

        void IDoor.DoorOpened()
        {
            if (!IsLocked)
            {
               DoorChanged(new DoorEventArgs { IsOpen = true });
            }
        }

        void IDoor.LockDoor()
        {
            IsLocked = true;
        }

        void IDoor.UnlockDoor()
        {
            IsLocked = false;
        }
       

    }
}
