using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public interface IWrite
    {
        string LockedMessage(int Id);
        string UnlockedMessage(int Id);
    }
}
