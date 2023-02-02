using System;

namespace CleanCode_3
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

    public interface IEmailSender
    {
        void Send(string email);
    }

    public class EmailSender : IEmailSender
    {
        public void Send(string email)
        {
            // Invia a --> email
            Console.WriteLine($"INVIO EMAIL ---> Grazie per aver acquistato l'auto");
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public decimal ListPrice { get; set; } 
        public decimal CustomerPrice { get; set; }

        private IPriceNegotiator _priceNegotiator;
        private IEmailSender _emailSender;

        public Car(IPriceNegotiator priceNegotiator, IEmailSender emailSender)
        {
            _priceNegotiator = priceNegotiator;
            _emailSender = emailSender;
        }

        public void Sell(Customer customer)
        {
            CustomerPrice = _priceNegotiator.NegotiatePrice(ListPrice);
            _emailSender.Send(customer.Email);
        }
    }



    class Program_3
    {
        static void Main_(string[] args)
        {
            Console.Clear();

            Car car = new Car(new GoldCustomerPriceNegotiator(), new EmailSender());
            car.Model = "Tesla";
            car.ListPrice = 50000;

            var cust = new Customer();
            cust.Name = "Pippo";
            cust.Email = "pippo@gmail.com";
            cust.IsGold = true;

            car.Sell(cust);

            Console.WriteLine($"Auto venduta a {car.CustomerPrice} €.");

            Console.ReadKey();
        }
    }
}
