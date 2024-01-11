using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
        public void OutOfRange()
        {
            try
            {
                hydroelectric.UpdateProduction(-1);
            }
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains("Procenat proizvodnje hidroelektrane je van opsega!",e.Message);
                return;
            }
            Assert.Fail("Exception nije bacen\n");
            
        }

        [Test]
        public void InRange()
        {
            try
            {
                hydroelectric.UpdateProduction(25);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains("Procenat proizvodnje hidroelektrane je van opsega!",e.Message);
                return;
            }
            Assert.Pass("Procenat proizvodnje je u opsegu!\n");

        }

        [TearDown]
        public void TearDown()
        {
            hydroelectric = null;
        }
    }
}
