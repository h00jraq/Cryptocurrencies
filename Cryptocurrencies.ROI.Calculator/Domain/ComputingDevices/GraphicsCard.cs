using Cryptocurrencies.ROI.Calculator.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    public class GraphicsCard : ComputingDevice
    {
        public GraphicsCard(decimal price, string model, string manufacturer, string version, int hashPower) 
            :base(price, model, manufacturer, version, hashPower)
        {
                
        }

    }
}
