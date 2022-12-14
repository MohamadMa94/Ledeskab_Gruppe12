using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{


    public class DoorEventArgs : EventArgs
    {
              public bool IsOpen { get; set; }
    }
    public interface IDoor
    {
        public event EventHandler<DoorEventArgs> DoorEvent;

        public void LockDoor();
        public void UnlockDoor();

        public void DoorOpened();

        public void DoorClosed();

    }
}
