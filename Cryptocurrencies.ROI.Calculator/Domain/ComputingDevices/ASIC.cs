using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    class ASIC : ComputingDevice
    {
        public ASIC(decimal price, string model, string manufacturer, string version, int hashPower)
            : base(price, model, manufacturer, version, hashPower)
        {

        }
    }
}
