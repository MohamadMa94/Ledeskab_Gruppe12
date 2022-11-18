using Ladeskab.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Test.Unit
{
    public class TestChargeControl
    {
        public ChargeControl _uut;
        public IDisplay _display;
        public IUsbCharger _usbCharger;
        private ChargeControl _tester;
        

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _usbCharger = Substitute.For<IUsbCharger>();
            _uut = new ChargeControl(_display, _usbCharger);
            _tester = new ChargeControl();
        }
        
        [Test]
        public void Test_Connected()
        {
            _usbCharger.Connected.Returns(true);
            Assert.That(_uut.Connected, Is.EqualTo(true));
        }
        
        
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

        
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(500)]
        public void Test_HandleCurrentValueChanged_CheckCurrent(double test_current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs()
            {
                Current = test_current
            });
            System.Threading.Thread.Sleep(500);
            Assert.That(_uut._Current, Is.EqualTo(test_current));
        }

        [TestCase(4)]
        [TestCase(1)]
        public void Test_HandleCurrentValueChanged_ChargeDone(double test_current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs()
            {
                Current = test_current
            });
            
            _display.Received().PhoneChargeDone();
            _display.DidNotReceive().PhoneCharging();
            _display.DidNotReceive().ConnectPhone();
        }

        
        public void Test_HandleCurrentValueChanged_NotCharging()
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs()
            {
                Current = 0
            });

            Assert.That(_uut._charging, Is.False);
        }

        
        [TestCase(500)]
        [TestCase(5.1)]
        public void Test_HandleCurrentValueChanged_Charging(double test_current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs()
            {
                Current = test_current
            });
            
            Assert.That(_uut._charging, Is.True);
        }
        [TestCase(500.1)]
        [TestCase(double.MaxValue)]
        [Test]
        public void NewCurrentDetected_Current_GreaterThan500(double test_current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = test_current });
            _display.Received().PhoneChargeDone();
            _usbCharger.Received().StopCharge();
        }
    }
}