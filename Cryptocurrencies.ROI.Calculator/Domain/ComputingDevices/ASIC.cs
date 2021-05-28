namespace Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices
{
    class ASIC : ComputingDevice
    {
        public ASIC(int id, decimal price, string model, string manufacturer, string version, long hashPower)
            : base(id, price, model, manufacturer, version, hashPower)
        {


        }
    }
}
