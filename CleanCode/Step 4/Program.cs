using System;
using System.Collections.Generic;

namespace CleanCode_4
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

    public interface IEmailSender
    {
        void Send(string email);
    }

    public class EmailSender : IEmailSender
    {
        public void Send(string email)
        {
            // Invia a --> email
            Console.WriteLine($"Grazie per aver acquistato l'auto");
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public decimal ListPrice { get; set; }

        private IEmailSender _emailSender;

        public Car(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

    }

    public class CarSeller
    {
        private PriceNegotiation _priceNegotiator;
        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public decimal CustomerPrice { get; set; }

        public CarSeller(PriceNegotiation priceNegotiator)
        {
            _priceNegotiator = priceNegotiator;
        }

        public void Sell()
        {
            CustomerPrice = _priceNegotiator.NegotiatePrice(Car.ListPrice);
        }
    }

    public abstract class PriceNegotiation
    {
        public abstract decimal NegotiatePrice(decimal listPrice);
    }

    public class GoldCustomerPriceNegotiator : PriceNegotiation
    {
        public override decimal NegotiatePrice(decimal listPrice)
        {
            return listPrice - (listPrice * 30 / 100);
        }
    }
    public class StandardCustomerPriceNegotiator : PriceNegotiation
    {
        public override decimal NegotiatePrice(decimal listPrice)
        {
            return listPrice - (listPrice * 10 / 100);
        }
    }

    public class PriceNegotiationFactory
    {
        private static readonly Dictionary<string, Func<PriceNegotiation>> _map = new Dictionary<string, Func<PriceNegotiation>>
    {
        { "True", () => new GoldCustomerPriceNegotiator() },
        { "False", () => new StandardCustomerPriceNegotiator() },
    };

        public static PriceNegotiation Create(string type)
        {
            if (_map.TryGetValue(type, out Func<PriceNegotiation> factoryMethod))
                return factoryMethod();
            else
                throw new ArgumentException("Argomento non valido");
        }
    }

    class Program_4
    {
        static void Main_4(string[] args)
        {
            Console.Clear();

            Car car = new Car(new EmailSender());
            car.Model = "Tesla";
            car.ListPrice = 50000;

            var cust = new Customer();
            cust.Name = "Pippo";
            cust.Email = "pippo@gmail.com";
            cust.IsGold = true;

            var CarSeller = new CarSeller(PriceNegotiationFactory.Create(cust.IsGold.ToString()));
            CarSeller.Car = car;
            CarSeller.Customer = cust;
            CarSeller.Sell();

            IEmailSender emailSender = new EmailSender();
            emailSender.Send(cust.Email);

            Console.WriteLine($"Auto venduta a {CarSeller.CustomerPrice} €.");

            Console.ReadKey();
        }
    }
}
