using Projekat.DistributionCenter;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.DistributionCenter;

namespace Projekat.Consumer
{
    public class Consumer
    {
        public int Potrosnja { get; set; }
        public List<Device> Devices { get; set; } = new List<Device>();

        

        public Consumer()
        {
            Potrosnja = 0;
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
                Console.WriteLine("Uredjaji:");

                // Prikazivanje dostupnih uređaja
                for (int i = 0; i < Devices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Devices[i].Name} (ON/OFF)");
                }
                Console.WriteLine("Izlazak iz programa - X\n");

                // Unos korisničkog izbora
                Console.Write("Unesite redni broj uređaja za uključivanje/isključivanje: ");
                answer = Console.ReadLine();
                if (int.TryParse(answer, out int selectedDeviceIndex) && selectedDeviceIndex >= 1 && selectedDeviceIndex <= Devices.Count)
                {
                    if (Devices[selectedDeviceIndex - 1].active == true)
                    {
                        Devices[selectedDeviceIndex - 1].TurnOff();
                        
                        Potrosnja -= Devices[selectedDeviceIndex - 1].ConsumptionPerHour;
                    }
                    else
                    {
                        Potrosnja += Devices[selectedDeviceIndex - 1].ConsumptionPerHour;
                        if (dist.ReceivePowerDemand(Potrosnja))
                            Devices[selectedDeviceIndex - 1].TurnOn();
                    }

                }
                
            } while (!answer.ToLower().Equals("x"));
        }
    }
}
