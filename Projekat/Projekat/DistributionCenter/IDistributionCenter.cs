using Projekat.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.DistributionCenter
{
    public interface IDistributionCenter
    {
        double ElectricityPricePerKWh { get; set; }
        void HandleRequest(IConsumer consumer);
    }
}
