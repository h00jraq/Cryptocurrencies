using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    public interface ICalculateROI
    {

        public decimal CalculateROIinDays(ComputingDevice device, int powerConsumptionPerHour, decimal energyPricePerKWH, decimal currencyRate);
    
    }
}
