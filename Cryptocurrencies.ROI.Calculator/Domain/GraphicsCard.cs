using Cryptocurrencies.ROI.Calculator.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    class GraphicsCard
    {
        private decimal _price;

        private string _model;

        private string _manufacturer;

        private string _version;

        private float _hashPower;

        public GraphicsCard(decimal price, string model, string manufacturer, string version, float hashPower)
        {
            Check.NullOrWhiteSpace(model, nameof(model));
            _price = price;
            _model = model;
            _manufacturer = manufacturer;
            _version = version;
            _hashPower = hashPower;
        }
    }
}
