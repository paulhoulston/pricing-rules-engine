namespace PricingEngine.Execution;

public class PricingRulesExecutor
{
    List<IAmAPricingRule> _rules = new();

    readonly Currency _currency;

    public PricingRulesExecutor(Currency currency) => _currency = currency;

    public Price GetPrice(bool answer = false)
    {
        var price = new Price(_currency);

        _rules.ForEach(rule => rule.Apply(price, answer));

        return price;
    }

    public void AddRule(IAmAPricingRule rule) => _rules.Add(rule);

    public interface IAmAPricingRule
    {
        void Apply(Price price, bool answer);
    }
}

public class AddAmountIfConditionEquals : PricingRulesExecutor.IAmAPricingRule
{
    public void Apply(Price price, bool answer)
    {
        if (answer)
        {
            price.Amount += 10;
        }
    }
}