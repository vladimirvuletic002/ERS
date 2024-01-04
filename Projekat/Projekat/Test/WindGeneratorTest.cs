using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Projekat.PowerPlant;

namespace Projekat.Test
{
    class WindGeneratorTest
    {
        public SolarPanelsAndWindGenerators.WindGenerator windGenerator;

        public void Setup()
        {
            windGenerator = new SolarPanelsAndWindGenerators.WindGenerator("Test");
        }

        [Test]
        [TestCase(125)]
        [TestCase(-50)]
        [TestCase(0)]
        [TestCase(50)]
        public void IsItInRange(double power)
        {
            windGenerator.Power = power;
            Assert.That(windGenerator.Power, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [TearDown]
        public void TearDown()
        {
            windGenerator = null;
        }
    }
}
