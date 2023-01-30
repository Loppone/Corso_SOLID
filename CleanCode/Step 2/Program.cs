using System;

namespace CleanCode_2
{
    public class Customer
    {
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public bool IsGold { get; internal set; }
    }

    public interface IPriceNegotiator
    {
        decimal NegotiatePrice(decimal listPrice);
    }

    public class GoldCustomerPriceNegotiator : IPriceNegotiator
    {
        public GoldCustomerPriceNegotiator()
        {
        }

        public decimal NegotiatePrice(decimal listPrice)
        {
            return listPrice - (listPrice * 30 / 100);
        }
    }

    public class StandardCustomerPriceNegotiator : IPriceNegotiator
    {
        public StandardCustomerPriceNegotiator()
        {
        }

        public decimal NegotiatePrice(decimal listPrice)
        {
            return listPrice - (listPrice * 10 / 100);
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public decimal ListPrice { get; set; } 
        public decimal CustomerPrice { get; set; }

        private IPriceNegotiator _priceNegotiator;

        public Car(IPriceNegotiator priceNegotiator)
        {
            _priceNegotiator = priceNegotiator;
        }

        public void Sell(Customer customer)
        {
            CustomerPrice = _priceNegotiator.NegotiatePrice(ListPrice);
            SendEmail(customer.Email);
        }

        private void SendEmail(string email)
        {
            Console.WriteLine($"Grazie per aver acquistato l'auto modello {Model}");
        }
    }



    class Program_2
    {
        static void Main2(string[] args)
        {
            Console.Clear();

            Car car = new Car(new GoldCustomerPriceNegotiator());
            car.Model = "Tesla";
            car.ListPrice = 50000;

            var cust = new Customer();
            cust.Name = "Pippo";
            cust.Email = "pippo@gmail.com";
            cust.IsGold = true;

            car.Sell(cust);

            Console.WriteLine($"Auto venduta a {car.CustomerPrice} €.");
        }
    }
}
