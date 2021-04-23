using Cryptocurrencies.ROI.Calculator.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    public class GraphicsCard
    {
        public decimal Price { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Version { get; set; }

        public int HashPower { get; set; }



        public GraphicsCard(decimal price, string model, string manufacturer, string version, int hashPower)
        {
            Check.GreaterThan(price, nameof(price));
            this.Price = price;
            Check.NullOrWhiteSpace(model, nameof(model));
            this.Model = model;
            Check.NullOrWhiteSpace(manufacturer, nameof(manufacturer));
            this.Manufacturer = manufacturer;
            Check.NullOrWhiteSpace(version, nameof(version));
            this.Version = version;
            Check.GreaterThan(hashPower, nameof(hashPower));
            this.HashPower = hashPower;
        }
    }
}
