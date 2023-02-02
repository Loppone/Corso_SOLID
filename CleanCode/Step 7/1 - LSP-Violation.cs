using System;

namespace CleanCode.Step_7A
{
    public class Car
    {
        public virtual void GetModel()
        {
            Console.WriteLine($"Auto generica");
        }

        public virtual void TankCapacity()
        {
            Console.WriteLine($"50 litri");
        }
    }

    public class Mercedes : Car
    {
        public override void GetModel()
        {
            Console.WriteLine($"Mercedes");
        }

        public override void TankCapacity()
        {
            Console.WriteLine($"60 litri");
        }
    }

    public class Tesla : Car
    {
        public override void GetModel()
        {
            Console.WriteLine($"Tesla");
        }

        public override void TankCapacity()
        {
            throw new NotImplementedException("NON HO IL SERBATOIO DELLA BENZINA :(");
        }
    }


    class Program
    {
        static void Main_(string[] args)
        {
            Console.Clear();

            Car tesla = new Tesla();
            tesla.TankCapacity();

            Car mercedes = new Mercedes();
            mercedes.TankCapacity();

            Console.ReadKey();
        }
    }
}
