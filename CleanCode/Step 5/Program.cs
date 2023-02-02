using System;
using System.Collections.Generic;

namespace CleanCode_5
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
        // LIVELLO 2
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

        public Car()
        {
        }
    }

    public interface ICarSeller
    {
        public decimal CustomerPrice { get; set; }
        public void Sell(Car car);
    }

    public class CarSeller : ICarSeller
    {
        // LIVELLO 2
        private PriceNegotiation _priceNegotiator;
        public decimal CustomerPrice { get; set; }

        public CarSeller(PriceNegotiation priceNegotiator)
        {
            _priceNegotiator = priceNegotiator;
        }

        public void Sell(Car car)
        {
            CustomerPrice = _priceNegotiator.NegotiatePrice(car.ListPrice);
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

    public class ShopCar
    {
        private readonly Car _car;
        private readonly Customer _customer;
        public ICarSeller CarSeller { get; set; }
        public IEmailSender EmailSender { get; set; }

        public ShopCar(Car car, Customer customer)
        {
            _car = car;
            _customer = customer;
        }

        public void SellOnlineCar()
        {
            // DIP
            #region Violazione
            //var CarSeller = new CarSeller(PriceNegotiationFactory.Create(cust.IsGold.ToString()));
            //CarSeller.Car = car;
            //CarSeller.Sell();

            //IEmailSender emailSender = new EmailSender();
            //emailSender.Send(cust.Email);

            //Console.WriteLine($"Auto venduta a {CarSeller.CustomerPrice} Euro.");
            #endregion

            #region Ok
            if (CarSeller == null)
            {
                Console.WriteLine("Si è verificato un problema irreversibile");
                //throw new Exception("NON E' BUONA PRATICA PASSARE LE DIPENDENZE TRAMITE PROPRIETA' QUANDO QUESTE SONO OBBLIGATORIE");
            }
            else
            {
                CarSeller.Sell(_car);
                Console.WriteLine($"Auto venduta a {CarSeller.CustomerPrice} Euro.");

                if (EmailSender != null)
                    EmailSender.Send(_customer.Email);
            }
            #endregion
        }
    }

    class Program_4
    {
        static void Main_(string[] args)
        {
            // LIVELLO 1
            Console.Clear();

            Car car = new Car();
            car.Model = "Tesla";
            car.ListPrice = 50000;

            var cust = new Customer();
            cust.Name = "Pippo";
            cust.Email = "pippo@gmail.com";
            cust.IsGold = true;

            var shopOnline = new ShopCar(car, cust);
            #region Sopresa
            //shopOnline.CarSeller = new CarSeller(PriceNegotiationFactory.Create(cust.IsGold.ToString()));
            //shopOnline.EmailSender = new EmailSender();
            #endregion
            shopOnline.SellOnlineCar();

            Console.ReadKey();
        }
    }

}
