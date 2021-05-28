using Cryptocurrencies.ROI.Calculator.HelperClasses;

namespace Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices
{
    public abstract class ComputingDevice
    {

        public int Id { get; set; }
        public decimal Price { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Version { get; set; }

        public long HashPower { get; set; }

        protected ComputingDevice(int id, decimal price, string model, string manufacturer, string version, long hashPower)
        {
            Check.GreaterThan(id, nameof(id));
            Check.GreaterThan(price, nameof(price));
            Check.NullOrWhiteSpace(model, nameof(model));
            Check.NullOrWhiteSpace(manufacturer, nameof(manufacturer));
            Check.GreaterThan(hashPower, nameof(hashPower));
            Check.NullOrWhiteSpace(version, nameof(version));

            Id = id;
            Price = price;
            Model = model;
            Manufacturer = manufacturer;
            Version = version;
            HashPower = hashPower;
        }
    }
}
