namespace PricingEngine.Execution;

public class Price
{
    public Price(Currency currency)
    {
        Amount = decimal.Zero;
        Currency = currency;
    }

    public decimal Amount { get; set; }
    public Currency Currency { get; private set; }
}