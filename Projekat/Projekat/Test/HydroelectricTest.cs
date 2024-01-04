using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Projekat.Test
{
    [TestFixture]
    class HydroelectricTest
    {
        public PowerPlant.Hydroelectric hydroelectric;

        [SetUp]
        public void Setup()
        {
            hydroelectric = new PowerPlant.Hydroelectric();
        }


        [Test]
        [TestCase(125)]
        [TestCase(-50)]
        [TestCase(0)]
        [TestCase(50)]
        public void IsItInRange(double power)
        {
            hydroelectric.Power = power;
            Assert.That(hydroelectric.Power, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [TearDown]
        public void TearDown()
        {
            hydroelectric = null;
        }
    }
}
