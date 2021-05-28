using Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices;

namespace Cryptocurrencies.ROI.Calculator.Domain.CryptoCurrencies
{
    public interface ICalculateRoi
    {

        public decimal CalculateRoIinDays(ComputingDevice device, int powerConsumptionPerHour, decimal energyPricePerKwh, double currencyRate);
    
    }
}
