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
        public void DoorClosed()
        {
            DoorChanged(new DoorEventArgs { IsOpen = false });

        }

        public void DoorOpened()
        {
            if (!IsLocked)
            {
               DoorChanged(new DoorEventArgs { IsOpen = true });
            }
        }

        public void LockDoor()
        {
            IsLocked = true;
        }

        public void UnlockDoor()
        {
            IsLocked = false;
        }
       

    }
}
