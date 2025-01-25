namespace PricingEngine.Execution;

public class Price
{
    public Price(Currency currency)
    {
        Amount = 0;
        Currency = currency;
    }

    public int Amount { get; set; }
    public Currency Currency { get; private set; }
}