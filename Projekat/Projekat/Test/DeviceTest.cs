using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Projekat.Consumer;

namespace Projekat.Test
{
    [TestFixture]
    class DeviceTest
    {
        public Consumer.Device dev;

        [Test]
        public void IsTurnedOn()
        {
            dev = new Device("Televizor",4);
            dev.TurnOn();

            ClassicAssert.AreEqual(dev.active, true);
        }

        public void IsTurnedOff()
        {
            dev = new Device("Grejalica", 1);
            dev.TurnOff();

            ClassicAssert.AreEqual(dev.active, false);
        }

        [TearDown]
        public void TearDown()
        {
            dev = null;
        }
    }
}
