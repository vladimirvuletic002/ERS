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
        }

        public double AvailablePower = 1000; 
        public static double CostPerKWh = 0.1; 

        //Primanje zahteva za potraznjom elektricne energije
        public bool ReceivePowerDemand(double power)
        {
            Console.WriteLine($"\nDistributivni centar: Potražnja za {power} kWh.");

            GetPower(SolarPanel, WindGen);
            Console.WriteLine($"{SolarPower}%, {WindPower}%");

            AdjustHydroelectricPlantProduction();

            if (AvailablePower >= power)
            {
                AvailablePower -= power;

                //cena potrosnje
                double cost = power * CostPerKWh;
                Console.WriteLine($"Distributivni centar: Poslato {power} kWh. Cena: {cost:C}\n");

                // Logovanje događaja u .txt fajl
                LogConsumer($"---{DateTime.Now}: - Potražnja za {power} kWh, Cena: {cost:C}---");
                LogConsumer($"---{DateTime.Now}: - Primljeno {power} kWh, Cena: {cost:C}---\n");
                return true;
            }
            else
            {
                Console.WriteLine("Distributivni centar: Nema dovoljno dostupne energije.\n");
                return false;
            }
        }

        //Dobavljanje obnovljivih izvora
        public void GetPower(SolarPanel solarPanel, WindGenerator windGenerator)
        {
            SolarPower = solarPanel.Power;
            WindPower = windGenerator.Power;
        }

        //Regulisanje rada hidroelektrane
        public void AdjustHydroelectricPlantProduction()
        {
            
            HydroEl.Power = (SolarPower + WindPower) / 2;
            AvailablePower = AvailablePower * (HydroEl.Power/100);
            HydroEl.Log();

        }


        public void LogConsumer(string logMessage)
        {
            File.AppendAllText("log_consumer.txt", $"{logMessage}\n");
        }
    }

}
