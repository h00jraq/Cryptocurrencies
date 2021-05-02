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
                new GraphicsCard(1450, "RTX 3070", "MSI", "Gaming OC", 98),
                new ASIC(6200, "Whatsminer M3270", "Whatsminer", "70", 2000),
                new ASIC(10000, "Antminer S7", "Antminer", "Turbo", 2500),
                new ASIC(7800, "CryptoMiner X21", "MiningFacility", "X21", 3300),
                new ASIC(10000, "AvalonMiner 1246", "Avalon", "1246", 3100),
                new ASIC(8500, "WhatsMiner M32-62T", "Whatsminer", "62T", 4100),
                new ASIC(9000, "AvalonMiner A1166 Pro", "Avalon", "70", 3800)
            };

    }
}
