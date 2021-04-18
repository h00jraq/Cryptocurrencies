using System;

namespace Cryptocurrencies.ROI.Calculator.HelperClasses
{
    static class Check
    {
        public static void NullOrWhiteSpace(string text, string parameterName)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"{parameterName} is invalid. ");
            }
        }

        public static void GreaterThan(decimal value, string parameterName, decimal than = 0)
        {
            if (value <= than)
            {
                throw new ArgumentException($"{parameterName} is invalid. ");
            }
        }

        public static void GreaterThan(float value, string parameterName, float than = 0)
        {
            if (value <= than)
            {
                throw new ArgumentException($"{parameterName} is invalid. ");
            }
        }

        public static void GreaterThan(int value, string parameterName, int than = 0)
        {
            if (value <= than)
            {
                throw new ArgumentException($"{parameterName} is invalid. ");
            }

        }
    }
}
