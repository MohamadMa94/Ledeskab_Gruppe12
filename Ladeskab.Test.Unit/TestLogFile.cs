using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Interfaces;


namespace Ladeskab.Test.Unit
{
    public class TestLogFile
    {
       
        private LogFile _uut;
        private IWrite _write;

        [SetUp]
        public void Setup()
        {
           _write = Substitute.For<IWrite>();
            _uut = new LogFile(_write);
        }

        [TestCase(1)]
        public void LogDoorLocked_CallsWriteLineLocked(int id)
        {
            _uut.LogDoorLocked(id);
            _write.Received(1).LockedMessage(id);
        }

        [TestCase(1)]
        public void LogDoorUnlocked_CallsWriteLineUnlocked(int id)
        {
            _uut.LogDoorUnlocked(id);
            _write.Received(1).UnlockedMessage(id);
        }
    }


}
