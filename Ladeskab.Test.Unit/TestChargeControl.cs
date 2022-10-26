using Ladeskab.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Test.Unit
{
    public class TestChargeControl
    {

        private ChargeControl _uut;
        private IDisplay _display;
        private IUsbCharger _usbCharger;
        private ChargeControl _tester;
        

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();
            _uut = new ChargeControl(_display,_usbCharger);
            _tester = new ChargeControl();
        }

        // Tester for at uut modtager startcharge og ikke stop charge
        [Test]
        public void Test_startCharge()
        {
            _uut.StartCharge();
            _usbCharger.Received(1).StartCharge();
            _usbCharger.DidNotReceive().StopCharge();
        }

        [Test]
        public void Test_stopCharge()
        {
            _uut.StopCharge();
            _usbCharger.Received(1).StopCharge();
            _usbCharger.DidNotReceive().StartCharge();
        }

    }
}