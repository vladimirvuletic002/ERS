using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.HydroelectricPowerPlant
{
    public class HydroelectricPowerPlantImpl : IHydroelectricPowerPlant
    {
        public double Regulation { get; private set; }

        public void UpdateRegulation()
        {
            // Logika za ažuriranje regulacije hidroelektrane
            Regulation = new Random().NextDouble();
            // Logika za čuvanje podataka u bazi podataka
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            // Logika za čuvanje podataka u bazi podataka
            string logEntry = $"{DateTime.Now}: Regulation: {Regulation * 100}%, Timestamp: {DateTime.Now}\n";
            File.AppendAllText("regulation_data.txt", logEntry);
        }
    }
}
