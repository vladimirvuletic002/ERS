using Projekat.Consumer;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.SolarPanelsAndWindGenerators;
using Projekat.PowerPlant;

namespace Projekat.DistributionCenter
{
    public class DistributiveCenter : IDistributionCenter
    {
        public double AvailablePower { get; set; }
        
        public static double CostPerKWh = 10;
        public double RenewablePower { get; set; }
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
            this.AvailablePower = 0;
            this.RenewablePower = 0;
            File.WriteAllText("log_consumer.txt", "Vreme, Prijem, Cena\n");
        } 

        //Primanje zahteva za potraznjom elektricne energije
        public bool ReceivePowerDemand(double power)
        {
            Console.WriteLine($"\nDistributivni centar: Potražnja za {power} kWh.");

            Console.WriteLine("\n\t*****************************************************");

            Console.WriteLine($"\n\tSolarni paneli: {SolarPanel.Production}%, Vetrogeneratori: {WindGen.Production}%\n");

            GetRenewablePower(SolarPanel, WindGen);

            AdjustHydroelectricPlantProduction(power);

            Console.WriteLine("\n\t*****************************************************");

            if (AvailablePower >= power)
            {
                

                //cena potrosnje
                double cost = power * CostPerKWh;
                Console.WriteLine($"Distributivni centar: Poslato {power} kWh. Cena: {cost}RSD\n");

                LogConsumer($"{DateTime.Now}, {power} kWh, {cost}RSD");
                return true;
            }
            else
            {
                Console.WriteLine("Distributivni centar: Nema dovoljno dostupne energije.\n");
                return false;
            }
        }

        //Dobavljanje obnovljivih izvora
        public void GetRenewablePower(SolarPanel solarPanel, WindGenerator windGenerator)
        {
            RenewablePower = (SolarPanel.Production/100) + (WindGen.Production/100);
        }

        //Regulisanje rada hidroelektrane
        public void AdjustHydroelectricPlantProduction(double demand)
        {
            int production = Convert.ToInt32(((demand - RenewablePower) / 15) * 100);
            HydroEl.UpdateProduction(production);
            AvailablePower =  SolarPanel.Production * 0.05 + WindGen.Production * 0.05 + HydroEl.Production * 0.9;
            Console.WriteLine($"\n\tSnaga: {AvailablePower}");
            Console.WriteLine($"\n\tProcenat rada hidroelektrane: {HydroEl.Production}%");
            HydroEl.Log();

        }


        public void LogConsumer(string logMessage)
        {
            File.AppendAllText("log_consumer.txt", $"{logMessage}\n");
        }
    }

}
