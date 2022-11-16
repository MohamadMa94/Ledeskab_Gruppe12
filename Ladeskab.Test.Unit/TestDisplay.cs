using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;
using NSubstitute;
using NUnit.Framework;
namespace Ladeskab.Test.Unit
{
    [TestFixture]
    public class TestDisplay
    {
        private Display _display;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<Display>();
        }
        
        [Test]

        public void Phone_Is_Connect()
        {
            _display.ConnectPhone();
            _display.Received(1).ConnectPhone();
        }
        [Test]
        public void Erorr_Phone_Is_Not_Connect()
        {
            _display.Erorr_ConnectPhone();
            _display.Received(1).Erorr_ConnectPhone();
        }
        [Test]
        public void Rfid_Read()
        {
            _display.ReadRfid();
            _display.Received(1).ReadRfid();
        }
        [Test]
        public void Erorr_Rfid_Not_Read()
        {
            _display.Erorr_ReadRfid();
            _display.Received(1).Erorr_ReadRfid();
        }

     
        [Test]
        public void Phone_Charging()
        {
            _display.PhoneCharging();
            _display.Received(1).PhoneCharging();
        }

        [Test]
        public void Erorr_Phone_Not_Charging()
        {
            _display.Erorr_PhoneCharging();
            _display.Received(1).Erorr_PhoneCharging();
        }

        [Test]
        public void PhoneCharge_Is_Full()
        {
            _display.PhoneChargeDone();
            _display.Received(1).PhoneChargeDone();
        }
    }
}
