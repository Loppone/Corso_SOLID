using System;
using System.Collections.Generic;

namespace CleanCode.OCP
{
    class Program
    {
        static void Main_(string[] args)
        {
            Console.Clear();

            var cars = new List<Car>()
            {
                new Car() { Color = "White", ModelName = "Mercedes CLA 220", TypeOfFuel=FuelType.Gasolio },
                new Car() { Color = "Red", ModelName = "Audi A4", TypeOfFuel=  FuelType.Gasolio },
                new Car() { Color = "Green", ModelName = "Subaru Baracca", TypeOfFuel=FuelType.Benzina }
            };

            var serviceStation = new ServiceStation();

            foreach (var car in cars)
            {
                serviceStation.Refuel(car);
                Console.WriteLine($"Ho fatto il pieno di {((FuelType)car.TypeOfFuel).ToString()} a {car.ModelName}");
            }

            Console.ReadKey();
        }
    }
}
