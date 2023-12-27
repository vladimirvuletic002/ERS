using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.HydroelectricPowerPlant
{
    public interface IHydroelectricPowerPlant
    {
        double Regulation { get; }
        void UpdateRegulation();
    }
}
