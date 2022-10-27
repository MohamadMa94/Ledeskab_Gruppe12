using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public interface IDisplay
    {
        void ConnectPhone();
        void Erorr_ConnectPhone();
        void ReadRfid();
        void Erorr_ReadRfid();
        void PhoneCharging();
        void Erorr_PhoneCharging();

        void PhoneChargeDone();


    }
}
