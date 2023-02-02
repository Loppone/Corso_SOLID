namespace CleanCode.OCP
{
    public class ServiceStation
    {
        public void Refuel(Car car)
        {
            car.IsFilledUp = true;
        }
    }
}
