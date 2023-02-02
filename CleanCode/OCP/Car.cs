namespace CleanCode.OCP
{
    public class Car
    {
        public string ModelName { get; set; }
        public string Color { get; set; }
        public FuelType TypeOfFuel { get; set; }
        public bool IsFilledUp { get; set; } = false;
    }
}
