using Ladeskab.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Test.Unit
{
    class TestStationControl
    {
        private IDisplay _display;
        private IDoor _door;
        private ILogFile _logfile;
        private IRfidReader _rfidReader;
        private IChargeControl _chargeControl;
        private StationControl _uut;
        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _logfile = Substitute.For<ILogFile>();
            _rfidReader = Substitute.For<IRfidReader>();
            _chargeControl = Substitute.For<IChargeControl>();
            _uut  = new StationControl(_door, _chargeControl, _rfidReader, _display, _logfile);
        }
    }
}