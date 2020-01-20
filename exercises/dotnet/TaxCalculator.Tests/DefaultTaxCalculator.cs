using System;
namespace TaxCalculator.Tests
{
    public class DefaultTaxCalculator : TaxCalculator
    {
        public DefaultTaxCalculator()
        {
        }

        public override int CalculateTax(Vehicle vehicle)
        {
            int vehicleCo2Emissions = vehicle.Co2Emissions;
            int? firstTaxPayment = null;

            switch (vehicleCo2Emissions)
            {
                case 0:
                    firstTaxPayment = 0;
                    break;
                case int n when (n < 51 && n >= 1):
                    firstTaxPayment = 10;
                    break;
                case int n when (n < 76 && n >= 51):
                    firstTaxPayment = 25;
                    break;
                case int n when (n < 91 && n >= 76):
                    firstTaxPayment = 105;
                    break;
                case int n when (n < 101 && n >= 91):
                    firstTaxPayment = 125;
                    break;
                case int n when (n < 111 && n >= 101):
                    firstTaxPayment = 145;
                    break;
                case int n when (n < 131 && n >= 111):
                    firstTaxPayment = 165;
                    break;
                case int n when (n < 151 && n >= 131):
                    firstTaxPayment = 205;
                    break;
                case int n when (n < 171 && n >= 151):
                    firstTaxPayment = 515;
                    break;
                case int n when (n < 191 && n >= 171):
                    firstTaxPayment = 830;
                    break;
                case int n when (n < 226 && n >= 191):
                    firstTaxPayment = 1240;
                    break;
                case int n when (n < 256 && n >= 226):
                    firstTaxPayment = 1760;
                    break;
                case int n when (n >= 256):
                    firstTaxPayment = 2070;
                    break;
            }

            if (firstTaxPayment == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                return firstTaxPayment.Value;
            }
        }
    }
}
