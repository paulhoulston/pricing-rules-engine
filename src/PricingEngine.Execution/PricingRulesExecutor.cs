namespace PricingEngine.Execution;


public class PricingRulesExecutor
{
    public enum Currency
    {
        GBP
    }

    List<Action<Price>> _rules = new();

    public class Price
    {
        public Price(int amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public int Amount { get; set; }
        public Currency Currency { get; private set; }
    }

    readonly Currency _currency;

    public PricingRulesExecutor(Currency currency) => _currency = currency;

    public Price GetPrice(bool answer = false)
    {
        var price = new Price(0, _currency);

        _rules.ForEach(rule => rule(price));
        
        return price;
    }

    public void AddRule(Action<Price> rule)
    {
        _rules.Add(rule);
    }
}
