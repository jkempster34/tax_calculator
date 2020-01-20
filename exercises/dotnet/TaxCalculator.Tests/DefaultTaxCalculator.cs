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

            if (vehicleCo2Emissions == 0)
            {
                return 0;
            }
            else if (vehicleCo2Emissions < 51)
            {
                return 10;
            }
            else if (vehicleCo2Emissions < 76)
            {
                return 25;
            }
            else if (vehicleCo2Emissions < 91)
            {
                return 105;
            }
            else if (vehicleCo2Emissions < 101)
            {
                return 125;
            }
            else if (vehicleCo2Emissions < 111)
            {
                return 145;
            }
            else if (vehicleCo2Emissions < 131)
            {
                return 165;
            }
            else if (vehicleCo2Emissions < 151)
            {
                return 205;
            }
            else if (vehicleCo2Emissions < 171)
            {
                return 515;
            }
            else if (vehicleCo2Emissions < 191)
            {
                return 830;
            }
            else if (vehicleCo2Emissions < 226)
            {
                return 1240;
            }
            else if (vehicleCo2Emissions < 256)
            {
                return 1760;
            }
            else if (vehicleCo2Emissions >= 256)
            {
                return 2070;
            }

            return 0;
        }
    }
}
