namespace CleanCode.Step_6B
{
    public interface IVehicle
    {
        void Accelerate();
        void Brake();
    }

    public interface IMotorizedVehicle : IVehicle
    {
        void StartEngine();
    }

    public interface IFlyingVehicle : IVehicle
    {
        void Fly();
    }

    public interface IWaterVehicle : IVehicle
    {
        void Swim();
    }

    public class Car : IMotorizedVehicle
    {
        public void Accelerate()
        {
            // Accelera
        }

        public void Brake()
        {
            // Frena
        }

        public void StartEngine()
        {
            // Accendi
        }
    }

    public class Airplane : IFlyingVehicle
    {
        public void Accelerate()
        {
            // Accelera
        }

        public void Brake()
        {
            // Frena
        }

        public void Fly()
        {
            // Vola
        }
    }

    public class Bycicle : IVehicle
    {
        public void Accelerate()
        {
            // Pedala
        }

        public void Brake()
        {
            // Frena
        }
    }
}
