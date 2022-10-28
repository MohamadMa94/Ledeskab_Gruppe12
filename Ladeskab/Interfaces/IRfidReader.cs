using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public class RfidEventArgs : EventArgs
    {
        public int IdTag { set; get; }
    }

    

    public interface IRfidReader
    {
        public event EventHandler<RfidEventArgs> RfidTagRead;
        

        void RfidRead(UInt32 Id);

    }
}
