using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projekat.PowerPlant
{
    public class Hydroelectric : IHydroelectric
    {
        public double Power { get; set; }

        public Hydroelectric() {
            this.Power = 0;
        }

        public void Log()
        {
            string log = $"{DateTime.Now}: Power: {Power}%\n";
            File.AppendAllText("hydroEl.txt", log);
        }
    }
}
