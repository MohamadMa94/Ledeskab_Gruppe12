using ImpLadeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbSimulator;

namespace ImpLadeskab
{
    public class ChargeControl : IChargeControl
    {
        IUsbCharger _USBCharger;

        public double ControlCurrent {get; private set; }

        public ChargeControl()
        {
            _USBCharger = new UsbChargerSimulator();
            _USBCharger.CurrentValueEvent += HandleCurrentValueChanged;
        }

        public bool Connected
        {
            get { return _USBCharger.Connected; } private set { }
        }

        public void StartCharge()
        {

        }

        public void StopCharge()
        {

        }

        public void HandleCurrentValueChanged(object sender, CurrentEventArgs e)
        {
            ControlCurrent = e.Current;
        }


    }
}
