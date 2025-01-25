using PricingEngine.Execution.Rules;

namespace PricingEngine.Execution;

public class PricingRulesExecutor
{
    List<IAmAPricingRule> _rules = new();

    readonly Currency _currency;

    public PricingRulesExecutor(Currency currency) => _currency = currency;

    public Price CalculatePrice(bool answer = false)
    {
        var price = new Price(_currency);

        _rules.ForEach(rule => rule.Apply(price, answer));

        return price;
    }

    public void AddRule(IAmAPricingRule rule) => _rules.Add(rule);
}