using System;

namespace CleanCode.Step_7A
{
    public class TeslaCar
    {
        public virtual void GetModel()
        {
            Console.WriteLine($"Modello Tesla");
        }
    }

    public class MercedesCar : TeslaCar
    {
        public override void GetModel()
        {
            Console.WriteLine($"Modello Mercedes");
        }
    }

    public class SubaruCar : TeslaCar
    {
        public override void GetModel()
        {
            throw new NotImplementedException();
        }
    }


    class Program
    {
        static void Main_7A(string[] args)
        {
            Console.Clear();

            TeslaCar tesla = new TeslaCar();
            tesla.GetModel();

            //TeslaCar tesla2 = new MercedesCar();
            //tesla2.GetModel();

            //TeslaCar tesla3 = new SubaruCar();
            //tesla3.GetModel();

            Console.ReadKey();
        }
    }
}
