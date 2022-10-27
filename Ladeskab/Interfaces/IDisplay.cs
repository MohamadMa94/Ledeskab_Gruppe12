using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladeskab.Interfaces
{
    public interface IDisplay
    {
        public void ConnectPhone();
        public void Erorr_ConnectPhone();
        public void ReadRfid();
        public void Erorr_ReadRfid();
        public void PhoneCharging();
        public void Erorr_PhoneCharging();

        public void PhoneChargeDone();


    }
}
