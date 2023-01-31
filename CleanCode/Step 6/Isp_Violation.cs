namespace CleanCode.Step_6A
{
    public interface IVehicle
    {
        void StartEngine();
        void Accelerate();
        void Brake();
        void Fly();
        void Swim();
    }

    public class Car : IVehicle
    {
        public void StartEngine()
        {
            // Accendi
        }

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
            throw new System.NotImplementedException();
        }

        public void Swim()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Airplane : IVehicle
    {
        public void StartEngine()
        {
            // Accendi
        }

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

        public void Swim()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Bycicle : IVehicle
    {
        public void StartEngine()
        {
            throw new System.NotImplementedException();
        }

        public void Accelerate()
        {
            // Pedala
        }

        public void Brake()
        {
            // Frena
        }

        public void Fly()
        {
            throw new System.NotImplementedException();
        }

        public void Swim()
        {
            throw new System.NotImplementedException();
        }
    }
}
