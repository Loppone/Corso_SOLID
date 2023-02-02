using System;
using System.Collections.Generic;

namespace CleanCode.OCP_Refactoring_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var cars = new List<IMotorVehicle>()
            {
                new GasolineCar() { Color = "White", ModelName = "Mercedes CLA 220", TypeOfFuel=FuelType.Gasolio },
                new GasolineCar() { Color = "Red", ModelName = "Audi A4", TypeOfFuel=  FuelType.Benzina },
                new GasolineCar() { Color = "Green", ModelName = "Subaru Impreza", TypeOfFuel=FuelType.GPL },
                new ElectricCar() { Color = "Blue", ModelName = "Tesla Model S", TypeOfFuel=FuelType.Elettrico },
                new HydrogenCar() { Color = "Black", ModelName = "Lamborghini Aventador", TypeOfFuel=FuelType.Idrogeno }
            };

            foreach (var car in cars)
            {
                car.MakeFuel();
            }

            Console.ReadKey();
        }
    }


    #region Car Model

    public interface IRefuel
    {
        void MakeFuel();
    }

    public interface IMotorVehicle : IRefuel
    {
        bool IsFilledUp { get; set; }
        string ModelName { get; set; }
        FuelType TypeOfFuel { get; set; }
    }

    public class GasolineCar : IMotorVehicle
    {
        public string ModelName { get; set; }
        public FuelType TypeOfFuel { get; set; }
        public bool IsFilledUp { get; set; } = false;

        // Altre proprietà...
        public string Color { get; set; }

        public void MakeFuel()
        {
            Console.WriteLine($"Ho fatto il pieno di {TypeOfFuel} a {ModelName}");
        }
    }

    public class ElectricCar : IMotorVehicle
    {
        public string ModelName { get; set; }
        public FuelType TypeOfFuel { get; set; }
        public bool IsFilledUp { get; set; } = false;

        // Altre proprietà...
        public string Color { get; set; }

        public void MakeFuel()
        {
            Console.WriteLine($"Ho caricato le batterie a {ModelName}");
        }
    }

    public class HydrogenCar : IMotorVehicle
    {
        public string ModelName { get; set; }
        public FuelType TypeOfFuel { get; set; }
        public bool IsFilledUp { get; set; } = false;

        // Altre proprietà...
        public string Color { get; set; }

        public void MakeFuel()
        {
            Console.WriteLine($"Ho Ho riempito le celle di {TypeOfFuel} a {ModelName}");
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
