using Projekat.DistributionCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Consumer
{
    public interface IConsumer
    {
        string Name { get; set; }
        void RequestElectricity(IDistributionCenter distributionCenter);
        void ReceiveElectricity(double amount, double cost);
    }
}
