using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Projekat.PowerPlant;
using Projekat.SolarPanelsAndWindGenerators;

namespace Projekat.Test
{
    [TestFixture]
    class WindGeneratorTest
    {
        public SolarPanelsAndWindGenerators.WindGenerator windGenerator;

        [SetUp]
        public void Setup()
        {
            windGenerator = new SolarPanelsAndWindGenerators.WindGenerator("Test");
        }

        [Test]
        [TestCase(0)]
        [TestCase(50)]
        public void InRange(int power)
        {
            windGenerator.Production = power;
            Assert.That(windGenerator.Production, Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(100));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(101)]
        public void OutOfRange(int power)
        {
            windGenerator.Production = power;
            Assert.That(windGenerator.Production, Is.LessThan(0).Or.GreaterThan(100));
        }

        [TearDown]
        public void TearDown()
        {
            windGenerator = null;
        }
    }
}
