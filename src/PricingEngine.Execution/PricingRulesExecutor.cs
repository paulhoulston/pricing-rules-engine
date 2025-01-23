namespace PricingEngine.Execution;


public class PricingRulesExecutor
{
    public enum Currency
    {
        GBP
    }

    public class Price
    {
        public Price(int amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public int Amount { get; private set; }
        public Currency Currency { get; private set; }
    }

    readonly Currency _currency;

    public PricingRulesExecutor(Currency currency) => _currency = currency;

    public Price GetPrice()
    {
        return new Price(0, _currency );
    }
}
