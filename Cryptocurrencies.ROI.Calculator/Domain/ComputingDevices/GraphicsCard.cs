namespace Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices
{
    public class GraphicsCard : ComputingDevice
    {
        public GraphicsCard(int id, decimal price, string model, string manufacturer, string version, int hashPower) 
            :base(id, price, model, manufacturer, version, hashPower)
        {
                
        }

    }
}
