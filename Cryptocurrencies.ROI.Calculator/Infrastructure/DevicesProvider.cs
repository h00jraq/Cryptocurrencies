using Cryptocurrencies.ROI.Calculator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptocurrencies.ROI.Calculator.Domain.ComputingDevices;

namespace Cryptocurrencies.ROI.Calculator.Infrastructure
{
    public static class DevicesProvider
    {
        public static readonly List<ComputingDevice> AvailableDevices = new()
            {
                new GraphicsCard(1, 1000, "GTX 1080", "MSI", "Gaming X", 40),
                new GraphicsCard(2, 2000, "RTX 3080", "MSI", "OC 3", 100),
                new GraphicsCard(3, 2000, "RTX 3090", "MSI", "OC 3", 130),
                new GraphicsCard(4, 3000, "RTX 3090", "Asus", "TUF", 140),
                new GraphicsCard(5, 2100, "RTX 3080", "EVGA", "Ultra", 105),
                new GraphicsCard(6, 1500, "RTX 3070", "Asus", "OC 2", 70),
                new GraphicsCard(7, 2100, "RTX 3080", "Asus", "ROG Strix", 105),
                new GraphicsCard(8, 2000, "RTX 3080", "Gigabyte", "Gaming Trio", 95),
                new GraphicsCard(9, 3150, "RTX 3090", "Asus", "ROG Strix", 145),
                new GraphicsCard(10, 1250, "RTX 3060", "Asus", "TUF", 80),
                new GraphicsCard(11, 1350, "RTX 3060 Ti", "MSI", "Gaming X", 85),
                new GraphicsCard(12, 1450, "RTX 3070", "MSI", "Gaming OC", 98),
                new ASIC(13, 49000, "Whatsminer M3270", "Whatsminer", "70", 100000000000000),
                new ASIC(14, 55000, "Antminer S7", "Antminer", "Turbo", 115000000000000),
                new ASIC(15, 45000, "CryptoMiner X21", "MiningFacility", "X21", 90000000000000),
                new ASIC(16, 51000, "AvalonMiner 1246", "Avalon", "XC Core", 950000000000000),
                new ASIC(17, 60000, "WhatsMiner M32-62T", "Whatsminer", "62T-Pro", 120000000000000),
                new ASIC(18, 58000, "AvalonMiner A1166 Pro", "Avalon", "Pro XT Turbo", 115000000000000)
            };

    }
}
