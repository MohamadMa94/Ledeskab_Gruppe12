using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab
{
    public class RfidReader : IRfidReader
    {

        public event EventHandler<RfidEventArgs> RfidReaderEvent;

        public void RfidRead(int Id)
        {
            RfidReaderEvent?.Invoke(this, new RfidEventArgs() { IdTag = Id });
        }
        
    }
}
