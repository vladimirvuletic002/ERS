using Projekat.Consumer;
using Projekat.DistributionCenter;
using Projekat.HydroelectricPowerPlant;
using Projekat.SolarPanelsAnd_WindGenerators;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsumer consumer1 = new ConsumerImpl("Consumer1");
            IDistributionCenter distributionCenter = new DistributionCenterImpl { ElectricityPricePerKWh = 0.1 };
            ISolarPanelsAnd_WindGenerators solarPanel = new SolarPanelsAnd_WindGeneratorsImpl();
            IHydroelectricPowerPlant hydroelectricPowerPlant = new HydroelectricPowerPlantImpl();

            for (int i = 0; i < 5; i++)
            {
                // Simulacija sistema
                consumer1.RequestElectricity(distributionCenter);

                solarPanel.UpdatePower();
                hydroelectricPowerPlant.UpdateRegulation();

                // Pauza između iteracija
                Thread.Sleep(1000);
            }
        }
    }
}
