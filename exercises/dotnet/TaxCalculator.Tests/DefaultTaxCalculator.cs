using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Tests
{
    public class DefaultTaxCalculator : TaxCalculator
    {
        private bool ToggleFeatureAfterFirstYear { get; set; }
        private bool ToggleFeatureAfterFirstYearForExpensiveVehicleTest { get; set; }

        public DefaultTaxCalculator()
        {
        }

        public DefaultTaxCalculator(bool toggleFeatureAfterFirstYear, bool toggleFeatureAfterFirstYearForExpensiveVehicleTest)
        {
            ToggleFeatureAfterFirstYear = toggleFeatureAfterFirstYear;
            ToggleFeatureAfterFirstYearForExpensiveVehicleTest = toggleFeatureAfterFirstYearForExpensiveVehicleTest;
        }

        public override int CalculateTax(Vehicle vehicle)
        {
            var emissions = vehicle.Co2Emissions;
            int? cost = null;
            Dictionary<int, int> index = null;

            if(ToggleFeatureAfterFirstYearForExpensiveVehicleTest)
            {
                if (DateTime.Now.AddYears(-1).Year >= vehicle.DateOfFirstRegistration.Year && vehicle.ListPrice > 40000)
                {
                    switch (vehicle.FuelType)
                    {
                        case FuelType.Petrol:
                            return 450;
                        case FuelType.Diesel:
                            return 450;
                        case FuelType.AlternativeFuel:
                            return 440;
                        case FuelType.Electric:
                            return 310;
                    }
                }
            }

            if (ToggleFeatureAfterFirstYear)
            {
                if(DateTime.Now.AddYears(-1).Year >= vehicle.DateOfFirstRegistration.Year)
                {
                    switch (vehicle.FuelType)
                    {
                        case FuelType.Petrol:
                            return 140;
                        case FuelType.Diesel:
                            return 140;
                        case FuelType.AlternativeFuel:
                            return 130;
                    }
                }
            }

            switch (vehicle.FuelType)
            {
                case FuelType.Petrol:
                    index = PetrolPriceIndex.index;
                    break;
                case FuelType.Diesel:
                    index = DieselPriceIndex.index;
                    break;
                case FuelType.AlternativeFuel:
                    index = AlternativePriceIndex.index;
                    break;
                case FuelType.Electric:
                    return 0;
            }

            foreach (var taxband in index)
            {
                if (emissions <= taxband.Key)
                {
                    return taxband.Value;
                }
            }

            if (cost.HasValue)
            {
                return cost.Value;
            }
            else return -1;



        }
    }
}
