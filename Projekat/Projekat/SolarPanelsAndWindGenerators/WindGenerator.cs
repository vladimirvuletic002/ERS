using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Projekat.SolarPanelsAndWindGenerators
{
    public class WindGenerator : IPanelsAndGenerators
    {
        public double Power { get; set; }

        public string Name { get; set; }

        public readonly Timer timer;
        public static readonly object filelock = new object();

        public WindGenerator(string name)
        {
            Power = new Random().Next(0, 101);
            Name = name;
            timer = new Timer(5000);
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;

        }

        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            
                UpdatePower();
            
        }

        public void UpdatePower()
        {
            lock (filelock)
            {
                Power = new Random().Next(-5, 6);
                Power = Math.Max(0, Math.Min(100, Power));
                Log();
            }
            
        }

        public void Log()
        {
            lock (filelock)
            {
                string log = $"{DateTime.Now}: Power: {Power}%, Name: {Name}\n";
                File.AppendAllText("windgenerators_panel.txt", log);
            }
            
        }
    }
}

