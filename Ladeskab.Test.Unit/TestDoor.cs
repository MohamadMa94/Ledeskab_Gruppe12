using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ladeskab.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace Ladeskab.Test.Unit
{
    [TestFixture]
    public class TestDoor
    {
        private Door _uut;
        private DoorEventArgs _receivedEventArgs;


        [SetUp]
        public void Setup()
        {
            _receivedEventArgs = null;
            _uut = new Door();
           
            _uut.DoorEvent +=
              (o, args) =>
              {
                  _receivedEventArgs = args;
              };
        }


        [Test]
        public void LockDoor_isLock_er_true()
        {
           _uut.LockDoor();
            Assert.That(_uut.IsLocked, Is.EqualTo(true));
        }

        [Test]
        public void UnLockDoor_isLock_er_false()
        {
            _uut.UnlockDoor();
            Assert.That(_uut.IsLocked, Is.EqualTo(false));
        }

        [Test]
        public void DoorOpened_Istrue()
        {
            _uut.DoorOpened();
            Assert.That(_receivedEventArgs.IsOpen, Is.EqualTo(true));

        }

        [Test]
        public void Door_Isfalae()
        {
            _uut.DoorClosed();
            Assert.That(_receivedEventArgs.IsOpen, Is.EqualTo(false));

        }

    }
}