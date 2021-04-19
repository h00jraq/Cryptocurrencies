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
        public decimal price 
        { 
            get { return _price; } 
            set { _price = value; } 
        }

        private decimal _price;

        public string model
        {
            get { return _model; }
            set { _model = value; }
        }
        private string _model;

        public string manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        private string _manufacturer;

        public string version
        {
            get { return _version; }
            set { _version = value; }
        }
        private string _version;

        public int hashPower
        {
            get { return _hashPower; }
            set { _hashPower = value; }
        }
        private int _hashPower;


        public GraphicsCard(decimal price, string model, string manufacturer, string version, int hashPower)
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
