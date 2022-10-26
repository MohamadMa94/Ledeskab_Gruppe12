using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public class Write : IWrite
    {
        public string LockedMessage(int Id)
        {
            return DateTime.Now + ": Skab låst med RFID: " + Id;
        }

        public string UnlockedMessage(int Id)
        {
            return DateTime.Now + ": Skab låst op med RFID: " + Id;
        }
    }
}
