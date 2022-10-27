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

        void LockDoor();
        void UnlockDoor();

        void DoorOpened();

        void DoorClosed();

    }
}
