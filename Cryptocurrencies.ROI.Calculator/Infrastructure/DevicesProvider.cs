using Cryptocurrencies.ROI.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    public static class DevicesProvider
    {
        public static List<ComputingDevice> AvailableDevices = new List<ComputingDevice>()
            {
                new GraphicsCard(1000, "GTX 1080", "MSI", "Gaming X", 40),
                new GraphicsCard(2000, "RTX 3080", "MSI", "OC 3", 100),
                new GraphicsCard(3000, "RTX 3090", "Asus", "TUF", 140),
                new GraphicsCard(2100, "RTX 3080", "EVGA", "Ultra", 105),
                new GraphicsCard(1500, "RTX 3070", "Asus", "OC 2", 70),
                new GraphicsCard(2100, "RTX 3080", "Asus", "ROG Strix", 105),
                new GraphicsCard(2000, "RTX 3080", "Gigabyte", "Gaming Trio", 95),
                new GraphicsCard(3150, "RTX 3090", "Asus", "ROG Strix", 145),
                new GraphicsCard(1250, "RTX 3060", "Asus", "TUF", 80),
                new GraphicsCard(1350, "RTX 3060 Ti", "MSI", "Gaming X", 85),
                new GraphicsCard(1450, "RTX 3070", "MSI", "Gaming OC", 98)
            };

    }
}
