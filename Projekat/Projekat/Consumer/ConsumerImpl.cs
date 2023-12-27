using Projekat.DistributionCenter;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Consumer
{
    public class ConsumerImpl : IConsumer
    {
        public string Name { get; set; }

        public ConsumerImpl(string name)
        {
            Name = name;
        }

        public void RequestElectricity(IDistributionCenter distributionCenter)
        {
            Console.WriteLine($"{Name} is requesting electricity.");
            distributionCenter.HandleRequest(this);
        }

        public void ReceiveElectricity(double amount, double cost)
        {
            Console.WriteLine($"{Name} received {amount} kWh. Cost: {cost:C}");
            // Logika za zabeležavanje u .txt fajl
            string logEntry = $"{DateTime.Now}: {Name} received {amount} kWh. Cost: {cost:C}\n";
            File.AppendAllText("log.txt", logEntry);
        }
    }
}
