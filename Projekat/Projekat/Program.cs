using Projekat.Consumer;
using Projekat.DistributionCenter;
using Projekat.SolarPanelsAndWindGenerators;
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
            Consumer.Consumer consumer = new Consumer.Consumer();
            DistributiveCenter distributionCenter = new DistributiveCenter();
            SolarPanel solarPanel1 = new SolarPanel("solarPanel1");
            SolarPanel solarPanel2 = new SolarPanel("solarPanel2");
            WindGenerator windGen1 = new WindGenerator("windGen1");
            WindGenerator windGen2 = new WindGenerator("windGen2");


            Device televizor = new Device("Televizor", 4);
            Device ves_masina = new Device("Ves masina", 6);
            Device racunar = new Device("Racunar", 4);
            Device grejalica = new Device("Grejalica", 7);
            consumer.AddDevices(televizor);
            consumer.AddDevices(ves_masina);
            consumer.AddDevices(racunar);
            consumer.AddDevices(grejalica);
            consumer.UI(distributionCenter);

        }
    }
}
