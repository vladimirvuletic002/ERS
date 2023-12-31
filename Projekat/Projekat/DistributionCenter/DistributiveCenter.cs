using Projekat.Consumer;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DistributionCenter
{
    public class DistributiveCenter : IDistributionCenter
    {
        public static double AvailablePower = 1000; 
        public static double CostPerKWh = 0.1; 
        public static double HydroelectricPlantUtilization = 50; 

        public bool ReceivePowerDemand(double power)
        {
            Console.WriteLine($"\nDistributivni centar: Potražnja za {power} kWh.");

            if (AvailablePower >= power)
            {
                AvailablePower -= power;

                // Računanje potrebe za prilagođavanjem rada hidroelektrane
                //AdjustHydroelectricPlantProduction(demand);

                double cost = power * CostPerKWh;
                Console.WriteLine($"Distributivni centar: Poslato {power} kWh. Cena: {cost:C}\n");

                // Logovanje događaja u .txt fajl
                LogConsumer($"{DateTime.Now}: - Potražnja za {power} kWh, Cena: {cost:C}");
                LogConsumer($"{DateTime.Now}: - Primljeno {power} kWh, Cena: {cost:C}");
                return true;
            }
            else
            {
                Console.WriteLine("Distributivni centar: Nema dovoljno dostupne energije.\n");
                return false;
            }
        }

        public void AdjustHydroelectricPlantProduction(double demand)
        {
            
            HydroelectricPlantUtilization += demand / 10; //Povećava iskorišćenost za 10% svaki put
            HydroelectricPlantUtilization = Math.Max(0, Math.Min(100, HydroelectricPlantUtilization)); // Ograničava vrednosti na opseg od 0% do 100%

            
            //Log($"{DateTime.Now}: Promena rada hidroelektrane - Iskorišćenost: {HydroelectricPlantUtilization}%");
        }

        public void ReceiveSolarAndWindInformation(double solarPower, double windPower)
        {
            // Prima informacije o proizvodnji solarnih panela i vetrogeneratora
            // i ažurira rad hidroelektrane na osnovu tih informacija
            double totalRenewablePower = solarPower + windPower;
            AdjustHydroelectricPlantProduction(totalRenewablePower);

            //Log($"{DateTime.Now}: Informacije o proizvodnji solarnih panela i vetrogeneratora - Solarni paneli: {solarPower} kWh, Vetrogeneratori: {windPower} kWh");
        }

        public void CalculateAndSendEnergyCost(double demand)
        {
            // Računanje cene električne energije
            double cost = demand * CostPerKWh;

            Console.WriteLine($"Distributivni centar: Poslat izveštaj o ceni potrošaču. Cena: {cost:C}");

            //Log($"{DateTime.Now}: Izveštaj o ceni - Potražnja: {demand} kWh, Cena: {cost:C}");
        }

        public void LogConsumer(string logMessage)
        {
            File.AppendAllText("log_consumer.txt", $"{logMessage}\n");
        }
    }

}
