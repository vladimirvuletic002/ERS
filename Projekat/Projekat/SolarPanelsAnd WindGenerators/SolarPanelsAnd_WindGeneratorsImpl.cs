using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.SolarPanelsAnd_WindGenerators
{
    public class SolarPanelsAnd_WindGeneratorsImpl : ISolarPanelsAnd_WindGenerators
    {
        public double Power { get; private set; }

        public void UpdatePower()
        {
            // Logika za ažuriranje snage obnovljivog izvora energije
            Power = new Random().Next(0, 101);
            // Logika za čuvanje podataka u bazi podataka
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            // Logika za čuvanje podataka u bazi podataka
            string logEntry = $"{DateTime.Now}: Power: {Power}%, Timestamp: {DateTime.Now}\n";
            File.AppendAllText("power_data.txt", logEntry);
        }
    }
}
