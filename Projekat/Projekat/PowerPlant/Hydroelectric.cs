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
        public int Production { get; set; }

        public Hydroelectric() {
            this.Production = 0;
            File.WriteAllText("hydroEl.txt", "Vreme, Proizvodnja\n");
        }

        // Procenat proizvodnje mora biti u opsegu 0-100
        public void UpdateProduction(int production)
        {
            if(production >= 0 && production <= 100)
            {
                Production = production;
            }
            else
            {
                Console.WriteLine("Procenat proizvodnje hidroelektrane mora biti u opsegu 0-100%\n");
            }
        }

        public void Log()
        {
            string log = $"{DateTime.Now}, {Production}%\n";
            File.AppendAllText("hydroEl.txt", log);
        }
    }
}
