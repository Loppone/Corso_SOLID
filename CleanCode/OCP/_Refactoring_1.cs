using System;
using System.Collections.Generic;

namespace CleanCode.OCP_Refactoring_1
{
    class Program
    {
        static void Main_(string[] args)
        {
            Console.Clear();

            var cars = new List<Car>()
            {
                new Car() { Color = "White", ModelName = "Mercedes CLA 220", TypeOfFuel=FuelType.Gasolio },
                new Car() { Color = "Red", ModelName = "Audi A4", TypeOfFuel=  FuelType.Benzina },
                new Car() { Color = "Green", ModelName = "Subaru Impreza", TypeOfFuel=FuelType.GPL },
                new Car() { Color = "Blue", ModelName = "Tesla Model S", TypeOfFuel=FuelType.Elettrico },
                new Car() { Color = "Black", ModelName = "Lamborghini Aventador", TypeOfFuel=FuelType.Idrogeno }
            };

            var serviceStation = new ServiceStation();

            foreach (var car in cars)
            {
                serviceStation.Refuel(car);
            }

            Console.ReadKey();
        }
    }


#region Car Model
public class Car
{
    public string ModelName { get; set; }
    public string Color { get; set; }
    public FuelType TypeOfFuel { get; set; }
    public bool IsFilledUp { get; set; } = false;
}

#endregion


#region ServiceStation
public class ServiceStation
{
    public void Refuel(Car car)
    {
        car.IsFilledUp = true;

        switch (car.TypeOfFuel)
        {
            case FuelType.Benzina:
            case FuelType.Gasolio:
            case FuelType.GPL:
                Console.WriteLine($"Ho fatto il pieno di {car.TypeOfFuel} a {car.ModelName}");
                break;
            case FuelType.Elettrico:
                Console.WriteLine($"Ho caricato la batteria a {car.ModelName}");
                break;
            case FuelType.Idrogeno:
                Console.WriteLine($"Ho riempito le celle a {car.ModelName}");
                break;
        }
    }
}

#endregion


#region ENUM
public enum FuelType
{
    Benzina,
    Gasolio,
    GPL,
    Elettrico,
    Idrogeno
}

#endregion

}
