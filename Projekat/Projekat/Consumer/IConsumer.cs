using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.DistributionCenter;

namespace Projekat.Consumer
{
    public interface IConsumer
    {
        void UI(DistributiveCenter dist);
    }
}
