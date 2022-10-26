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
            _uut = new ChargeControl(_display, _usbCharger);
            _tester = new ChargeControl();
        }

        //Test til at se om vi kan se at telefonen er connected
        [Test]
        public void Test_Connected()
        {
            _usbCharger.Connected.Returns(true);
            Assert.That(_uut.Connected, Is.True);
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

        // Test for at se at vi kan ændre på current
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
            // Vi skal teste at display viser at charge er færdig
            // vi skal teste at display ikke viser at den lader
            // vi skal teste at display ikke viser at man skal tilslutte telefon
        }

        // Tester for at vi kan se at vores state ændre sig så når der ikke er noget der lader
        public void Test_HandleCurrentValueChanged_NotCharging()
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs()
            {
                Current = 0
            });

            Assert.That(_uut._charging, Is.False);
        }

        // Tester for at vi kan vise at vores state ændre sig når laderen bør lade
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
    }
}