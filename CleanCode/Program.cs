using System;

public class Customer
{
    public string Name { get; internal set; }
    public string Email { get; internal set; }
    public bool IsGold { get; internal set; }
}

public class Car
{
    public string Model { get; set; }
    public decimal ListPrice { get; set; }
    public decimal CustomerPrice
    {
        get { return _customerPrice; }
    }

    private decimal _customerPrice;

    public Car()
    {

    }

    public void Sell(Customer customer)
    {
        // SRP
        _customerPrice = NegotiatePrice(customer);
        SendEmail(customer.Email);
    }

    private void SendEmail(string email)
    {
        Console.WriteLine($"Grazie per aver acquistato l'auto modello {Model}");
    }

    private decimal NegotiatePrice(Customer customer)
    {
        // OCP
        if (customer.IsGold)
            return ListPrice - (ListPrice * 30 / 100);
        else
            return ListPrice - (ListPrice * 10 / 100);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var car = new Car();
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
