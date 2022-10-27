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
        public void ConnectPhone()
        {
            Console.WriteLine("Please connect your phone to the charging .\n");
        }

        public void Erorr_ConnectPhone()
        {
            Console.WriteLine("ERROR! The phone is not connected.\n");
        }

        public void Erorr_PhoneCharging()
        {
            Console.WriteLine("ERROR! Phone is not charging.\n");
        }

        public void Erorr_ReadRfid()
        {
            Console.WriteLine("ERROR! RFID chip is not on the lock.\n");
        }

        public void PhoneChargeDone()
        {
            Console.WriteLine("Phone is fully charged\n");
        }

        public void PhoneCharging()
        {
            Console.WriteLine("Phone is  charging.\n");
        }

        public void ReadRfid()
        {
            Console.WriteLine("Place RFID chip on the lock.\n");
        }

    }
}
