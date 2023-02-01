using System;

namespace CleanCode.Step_7B
{
    public abstract class Car
    {
        public abstract void GetModel();
    }

    public class Tesla : Car
    {
        public override void GetModel()
        {
            Console.WriteLine($"Modello Tesla");
        }
    }

    public class MercedesCar : Car
    {
        public override void GetModel()
        {
            Console.WriteLine($"Modello Mercedes");
        }
    }

    public class SubaruCar : Car
    {
        public override void GetModel()
        {
            Console.WriteLine($"Modello Subaru");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // LPS + OCP + DIP conforme
            Console.Clear();

            Car whatCarWillbe1 = new Tesla();
            whatCarWillbe1.GetModel();

            Car whatCarWillbe2 = new MercedesCar();
            whatCarWillbe2.GetModel();

            Car whatCarWillbe3 = new SubaruCar();
            whatCarWillbe3.GetModel();

            Console.ReadKey();
        }
    }
}
