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
        [TestCase("Televizor",4)]
        [TestCase("Ves masina", 6)]
        [TestCase("Racunar", 4)]
        [TestCase("Grejalica", 7)]



        public void CheckState(string name, int consumption)
        {
            dev = new Device(name, consumption);

            ClassicAssert.AreEqual(dev.active, true);
        }

        [TearDown]
        public void TearDown()
        {
            dev = null;
        }
    }
}
