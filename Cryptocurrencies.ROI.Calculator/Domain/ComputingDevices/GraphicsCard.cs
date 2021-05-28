namespace Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices
{
    public class GraphicsCard : ComputingDevice
    {
        public GraphicsCard(decimal price, string model, string manufacturer, string version, int hashPower) 
            :base(price, model, manufacturer, version, hashPower)
        {
                
        }

    }
}
