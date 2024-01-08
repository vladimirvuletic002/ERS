using Projekat.Consumer;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.SolarPanelsAndWindGenerators;
using Projekat.PowerPlant;
using System.Timers;

namespace Projekat.DistributionCenter
{
    public class DistributiveCenter : IDistributionCenter
    {
        public double AvailableEnergy { get; set; }

        public static double CostPerkWh = 10;
        public double RenewableEnergy { get; set; }
        public double SolarPower { get; set; }
        public double WindPower { get; set; }

        public SolarPanel SolarPanel { get; set; }
        public WindGenerator WindGen { get; set; }

        public Hydroelectric HydroEl { get; set; } = new Hydroelectric();
        public DistributiveCenter(SolarPanel solar, WindGenerator wind)
        {
            this.SolarPanel = solar;
            this.WindGen = wind;
            this.SolarPower = 0;
            this.WindPower = 0;
            this.AvailableEnergy = 0;
            this.RenewableEnergy = 0;
            File.WriteAllText("log_consumer.txt", "Vreme, Prijem, Cena\n");
        }

        //Primanje zahteva za potraznjom elektricne energije
        public bool ReceivePowerDemand(double consumption)
        {

            Console.WriteLine($"\nDistributivni centar: Potražnja za {consumption} kWh.");

            PrintDistributionStats(consumption);

            if (AvailableEnergy >= consumption)
            {
                //cena potrosnje = potraznja × cenakWh
                double cost = consumption * CostPerkWh;
                
                Console.WriteLine($"Distributivni centar: Poslato {consumption} kWh. Cena: {cost}RSD\n");

                LogConsumer($"{DateTime.Now}, {consumption} kWh, {cost}RSD");
                return true;
            }
            else
            {
                Console.WriteLine("Distributivni centar: Nema dovoljno dostupne energije.\n");
                return false;
            }
        }

        public void PrintDistributionStats(double consumption)
        {
            Console.WriteLine("\n\t*****************************************************");

            Console.WriteLine($"\n\tSolarni paneli: {SolarPanel.Production}%, Vetrogeneratori: {WindGen.Production}%\n");

            GetRenewablePower(SolarPanel, WindGen);

            AdjustHydroelectricPlantProduction(consumption);

            Console.WriteLine("\n\t*****************************************************\n");

        }

        //Dobavljanje obnovljivih izvora
        public void GetRenewablePower(SolarPanel solarPanel, WindGenerator windGenerator)
        {
            RenewableEnergy = (SolarPanel.Production/100) + (WindGen.Production/100);
        }

        //Regulisanje rada hidroelektrane
        public void AdjustHydroelectricPlantProduction(double demand)
        {
            int production = Convert.ToInt32(((demand - RenewableEnergy) / 15) * 100); // proizvodnja = ((potrosnja - obnovljiviIzvori) ÷ maxProizvodnja) × 100
            HydroEl.UpdateProduction(production);
            AvailableEnergy =  SolarPanel.Production * 0.05 + WindGen.Production * 0.05 + HydroEl.Production * 0.9;
            Console.WriteLine($"\n\tUkupna energija: {AvailableEnergy}");
            Console.WriteLine($"\n\tProcenat rada hidroelektrane: {HydroEl.Production}%");
            HydroEl.Log();

        }


        public void LogConsumer(string logMessage)
        {
            File.AppendAllText("log_consumer.txt", $"{logMessage}\n");
        }
    }

}
