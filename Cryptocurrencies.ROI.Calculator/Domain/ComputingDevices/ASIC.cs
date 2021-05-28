namespace Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices
{
    class ASIC : ComputingDevice
    {
        public ASIC(decimal price, string model, string manufacturer, string version, long hashPower)
            : base(price, model, manufacturer, version, hashPower)
        {


        }
    }
}
