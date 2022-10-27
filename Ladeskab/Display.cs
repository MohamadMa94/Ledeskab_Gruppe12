using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Display : IDisplay
    {

        void IDisplay.ConnectPhone()
        {
            Console.WriteLine("Please connect your phone to the charging .\n");
        }

        void IDisplay.Erorr_ConnectPhone()
        {
            Console.WriteLine("ERROR! The phone is not connected.\n");
        }

        void IDisplay.Erorr_PhoneCharging()
        {
            Console.WriteLine("ERROR! Phone is not charging.\n");
        }

        void IDisplay.Erorr_ReadRfid()
        {
            Console.WriteLine("ERROR! RFID chip is not on the lock.\n");
        }

        void IDisplay.PhoneCharging()
        {
            Console.WriteLine("Phone is currently charging.\n");
        }

        void IDisplay.ReadRfid()
        {
            Console.WriteLine("Place RFID chip on the lock.\n");
        }

    }
}
