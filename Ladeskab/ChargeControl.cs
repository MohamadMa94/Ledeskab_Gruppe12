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
            _charging = false;
            _display = new Display();
            _USBCharger = new UsbChargerSimulator();
            _USBCharger.CurrentValueEvent += HandleCurrentValueChanged;
        }

        public ChargeControl (IDisplay display, IUsbCharger usbCharger)
        {
            _display = display;
            _USBCharger = usbCharger;
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

        public void HandleCurrentValueChanged(object sender, CurrentEventArgs ea)
        {
            _Current = ea.Current;
            
            // Hvis der ikke er nogen tilslutning
            if (_Current == 0.0)
            {
                if (_charging == false)
                {
                    _display.ConnectPhone();
                    _charging = false;
                }
            }

            // Opladning slut
            else if (_Current == 5 && _Current > 0)
            {
                // Vis på display at opladning er slut
                _charging = false;
            }

            //Opladningen er igang
            else if (_Current <= 500 && _Current > 5 )
            {
                // Hvis på display at telefonen stadig lader
                _charging = true;
            }

            // Der er en fejl
            else
            {
                // vis på display at bruger skal unplugge telefon
                StopCharge();
            }
        }



    }
}
