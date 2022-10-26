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
            _display = Subsitute.For<IDisplay>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}