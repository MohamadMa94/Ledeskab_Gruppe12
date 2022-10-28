using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Ladeskab.Test.Unit
{
    public class TestRfidReader
    {
        private RfidReader _uut;
        private RfidEventArgs? _receivedEventArgs;

        [SetUp]
        public void Setup()
        {
            _uut = new RfidReader();

            _uut.RfidReaderEvent += (o, args) =>
            {
                _receivedEventArgs = args;
            };
        }

        [Test]
        public void SetReadRFID_RfidDetectedtSetToNewValue_EventFired()
        {
            _uut.RfidRead(33);
            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
        [Test]
        public void CorrectRfidRead()
        {
            _uut.RfidRead(34);
            Assert.That(_receivedEventArgs.IdTag, Is.EqualTo(34));
        }
    }
}
