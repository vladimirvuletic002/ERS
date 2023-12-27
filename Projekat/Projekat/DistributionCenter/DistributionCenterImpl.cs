using Projekat.Consumer;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DistributionCenter
{
    public class DistributionCenterImpl : IDistributionCenter
    {
        public double ElectricityPricePerKWh { get; set; }

        public void HandleRequest(IConsumer consumer)
        {
            // Logika za obradu zahteva potrošača
            double demand = CalculateDemand();
            double cost = demand * ElectricityPricePerKWh;

            consumer.ReceiveElectricity(demand, cost);
            LogEvents();
        }

        private double CalculateDemand()
        {
            // Logika za proračun potrebne energije
            return 10.0; // Primer - zamenite stvarnom logikom
        }

        private void LogEvents()
        {
            // Logika za logovanje događaja u .txt fajl
            string logEntry = $"{DateTime.Now}: Distribution Center handled a request.\n";
            File.AppendAllText("log.txt", logEntry);
        }
    }
}
