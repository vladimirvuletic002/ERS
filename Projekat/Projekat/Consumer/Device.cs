using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Consumer
{
    public class Device : IDevice
    {
        public string Name { get; set; }
        public int ConsumptionPerHour { get; set; }

        public bool active { get; set; }

        public Device(string name, int consumption)
        {
            this.Name = name;
            this.ConsumptionPerHour = consumption;
            this.active = false;
        }
        public bool TurnOff()
        {
            if(active == true)
            {
                active = false;
                Console.WriteLine("Iskljucili ste uredjaj {0}.\n", Name);
                return true;
            }
            else
            {
                Console.WriteLine("{0} je vec iskljucen/a.\n",Name);
                return false;
            }
        }

        public bool TurnOn()
        {
            if (active == false)
            {
                active = true;
                Console.WriteLine("Ukljucili ste uredjaj {0}.\n", Name);
                return true;
            }
            else
            {
                Console.WriteLine("{0} je vec ukljucen/a.\n", Name);
                return false;
            }
        }
    }
}
