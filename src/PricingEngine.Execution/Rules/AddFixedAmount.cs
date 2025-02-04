namespace PricingEngine.Execution.Rules;

public class AddFixedAmount : IAmAPricingRule
{
    readonly decimal _amount;

    public AddFixedAmount(decimal amount)
    {
        _amount = amount;
    }

    public void Apply(Price price, object answer)
    {
        price.Amount += _amount;
    }
}