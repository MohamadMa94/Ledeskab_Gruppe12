using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public interface ILogFile
    {
        void LogDoorLocked(int Id);

        void LogDoorUnlocked(int Id);

    }
}
