using Projekat.DistributionCenter;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Consumer
{
    public class Consumer : IConsumer
    {
        public double Consumption { get; set; }
        public List<Device> Devices { get; set; } = new List<Device>();

        public Consumer()
        {
            Consumption = 0;
        }

        public void AddDevices(Device device)
        {
            Devices.Add(device);
        }

        public void UI(DistributiveCenter dist)
        {
            string answer;
            do
            {

                Console.WriteLine("\n=============================================================");
                Console.WriteLine("Uredjaji:");

                // Prikaz dostupnih uređaja
                for (int i = 0; i < Devices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Devices[i].Name} (ON/OFF)");
                }
                Console.WriteLine("Izlazak iz programa - X\n");

                // Unos korisničkog izbora
                Console.Write("Unesite redni broj uređaja za uključivanje/isključivanje: ");
                Console.WriteLine("\n=============================================================");
                answer = Console.ReadLine();
                
                if (int.TryParse(answer, out int index) && index >= 1 && index <= Devices.Count)
                {
                    if (Devices[index - 1].active == true)
                    {
                        Devices[index - 1].TurnOff();
                        
                        Consumption -= Devices[index - 1].ConsumptionPerHour;
                        dist.PrintDistributionStats(Consumption);
                    }
                    else
                    {
                        Consumption += Devices[index - 1].ConsumptionPerHour;
                        if (dist.ReceivePowerDemand(Consumption))
                            Devices[index - 1].TurnOn();
                        else
                            Consumption -= Devices[index - 1].ConsumptionPerHour;
                    }

                }
                
            } while (!answer.ToLower().Equals("x"));
        }
    }
}
