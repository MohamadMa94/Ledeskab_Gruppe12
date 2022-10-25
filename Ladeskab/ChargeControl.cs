using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace Ladeskab
{
    public class ChargeControl : IChargeControl
    {
        IUsbCharger _USBCharger;
        IDisplay _display;

        public double _Current {get; private set; }
        public bool _charging { get; private set; }

        public ChargeControl()
        {
            _display = new display;
            _USBCharger = new UsbChargerSimulator();
            _USBCharger.CurrentValueEvent += HandleCurrentValueChanged;
        }

        public bool Connected
        {
            get { return _USBCharger.Connected; } private set { }
        }

        public void StartCharge()
        {
            _USBCharger.StartCharge();
        }

        public void StopCharge()
        {
            _USBCharger.StopCharge();
        }

        public void HandleCurrentValueChanged(object sender, CurrentEventArgs e)
        {
            if (_Current == 0.0)
            {
                if (_charging == false)
                {

                }
            }
        }


    }
}
