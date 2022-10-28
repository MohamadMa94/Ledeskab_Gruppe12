using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using NUnit.Framework;

namespace Ladeskab.Test.Unit
{
    public class TestWrite
    {
        private Write _uut;
        private StringWriter _output;

        [SetUp]
        public void Setup()
        {
            _uut = new Write();

            _output = new StringWriter();
            System.Console.SetOut(_output);
        }

        [TestCase(50)]
        public void LockedMessage_OutputString_IsEqualTo_Expected(int id)
        {
            string expected = DateTime.Now + ": Skab låst med RFID: " + id;

            string result = _uut.LockedMessage(id);

            Assert.AreEqual(expected, result);
        }

        [TestCase(50)]
        public void UnlockedMessage_OutputString_IsEqualTo_Expected(int id)
        {
            string expected = DateTime.Now + ": Skab låst op med RFID: " + id;

            string result = _uut.UnlockedMessage(id);

            Assert.AreEqual(expected, result);
        }
    }




}
