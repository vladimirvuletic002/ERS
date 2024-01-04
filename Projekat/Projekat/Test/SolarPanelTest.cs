using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Projekat.PowerPlant;

namespace Projekat.Test
{
    [TestFixture]
    class SolarPanelTest
    {
        public SolarPanelsAndWindGenerators.SolarPanel solarPanel;

        [SetUp]
        public void Setup()
        {
            solarPanel = new SolarPanelsAndWindGenerators.SolarPanel("Test");
        }

        [Test]
        [TestCase(125)]
        [TestCase(-50)]
        [TestCase(0)]
        [TestCase(50)]
        public void IsItInRange(double power)
        {
            solarPanel.Power = power;
            Assert.That(solarPanel.Power, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [TearDown]
        public void TearDown()
        {
            solarPanel = null;
        }
    }
}
