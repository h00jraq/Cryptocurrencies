﻿using Cryptocurrencies.ROI.Calculator.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Domain
{
    public abstract class ComputingDevice
    {
        public decimal Price { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public string Version { get; set; }

        public long HashPower { get; set; }

        public ComputingDevice(decimal price, string model, string manufacturer, string version, long hashPower)
        {
            Check.GreaterThan(price, nameof(price));
            Check.NullOrWhiteSpace(model, nameof(model));
            Check.NullOrWhiteSpace(manufacturer, nameof(manufacturer));
            Check.GreaterThan(hashPower, nameof(hashPower));
            Check.NullOrWhiteSpace(version, nameof(version));
            
            Price = price;
            Model = model;
            Manufacturer = manufacturer;
            Version = version;
            HashPower = hashPower;
        }
    }
}
