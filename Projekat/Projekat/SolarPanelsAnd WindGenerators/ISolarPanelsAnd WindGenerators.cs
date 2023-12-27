using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.SolarPanelsAnd_WindGenerators
{
    public interface ISolarPanelsAnd_WindGenerators
    {
        double Power { get; }
        void UpdatePower();
    }
}
