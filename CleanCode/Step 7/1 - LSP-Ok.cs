using System;

namespace CleanCode.Step_7B
{
    public abstract class Car
    {
        public abstract void GetModel();
    }

    public class Electric : Car
    {
        public override void GetModel()
        {
            Console.WriteLine($"Auto elettrica");
        }

        public virtual void BatteryCapacity()
        {
            Console.WriteLine($"Standard 10 Ah");
        }
    }

    public class Petrol : Car
    {
        public override void GetModel()
        {
            Console.WriteLine($"Auto a benzina/diesel");
        }

        public virtual void GasTankCapacity()
        {
            Console.WriteLine($"Standard 50 litri");
        }
    }

    public class Tesla : Electric
    {
        public override void GetModel()
        {
            Console.WriteLine($"Tesla");
        }

        public override void BatteryCapacity()
        {
            Console.WriteLine($"26 Ah");
        }
    }


    public class Mercedes : Petrol
    {
        public override void GetModel()
        {
            Console.WriteLine($"Mercedes");
        }

        public override void GasTankCapacity()
        {
            Console.WriteLine($"65 litri");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Car tesla = new Tesla();
            tesla.GetModel();

            Car mercedes = new Mercedes();
            mercedes.GetModel();

            Console.ReadKey();

            // TUTTO A POSTO, MA USANDO QUESTA ASTRAZIONE NON ABBIAMO ACCESSO AI SERBATOI
        }
    }
}
