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
        [Test]
        public void TestDoorClosed()
        {
            
            _door.DoorEvent += Raise.EventWith(new DoorEventArgs() { IsOpen = false });
            _door.DoorEvent += Raise.EventWith(new DoorEventArgs() { IsOpen = true });

            
            _display.Received(1).ReadRfid();
        }


        [Test]
        public void TestRfidDetectedLockDoor()
        {
            
            _chargeControl.Connected().Returns(true);
            _rfidReader.RfidReaderEvent += Raise.EventWith(new RfidEventArgs() { IdTag = 55 });
            _door.Received(1).LockDoor();
        }
        [Test]
        public void TestDoorOpened()
        {
            _door.DoorEvent += Raise.EventWith(new DoorEventArgs() { IsOpen = false });

             
            _display.Received(1).ConnectPhone();
        }

      
        [Test]
        public void TestRfidDetectedLockDoorFalse()
        {
            
            _chargeControl.Connected().Returns(false);
            _rfidReader.RfidReaderEvent += Raise.EventWith(new RfidEventArgs() { IdTag = 55 });
            _display.Received(1).Erorr_ConnectPhone();
        }
        [Test]
        public void TestRfidDetectedStartCharge()
        {
            _chargeControl.Connected().Returns(true);
            _rfidReader.RfidReaderEvent += Raise.EventWith(new RfidEventArgs() { IdTag = 55 });
            _door.Received(1).LockDoor();
            _display.Received(1).PhoneCharging();
        }
        [Test]
        public void TestRfidDetectedOldEqualNewIDUnlock()
        {
            _chargeControl.Connected().Returns(true);
            _rfidReader.RfidReaderEvent += Raise.EventWith(new RfidEventArgs() { IdTag = 55 });
            _rfidReader.RfidReaderEvent += Raise.EventWith(new RfidEventArgs() { IdTag = 55 });

            _chargeControl.Received(1).StopCharge();
            _door.Received(1).UnlockDoor();
        }
        [Test]
        public void TestRfidDetectedLockedID()
        {
            _chargeControl.Connected().Returns(true);
            _rfidReader.RfidReaderEvent += Raise.EventWith(new RfidEventArgs() { IdTag = 55 });

            _rfidReader.RfidReaderEvent += Raise.EventWith(new RfidEventArgs() { IdTag = 5555 });
            _display.Received(1).Erorr_ReadRfid();

        }

    



    }
}