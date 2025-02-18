namespace PricingEngine.Execution.Rules;

using PricingEngine.Execution;

public class AddFixedAmount : IAmAPricingRule
{
    readonly decimal _amount;

    public AddFixedAmount(decimal amount)
    {
        _amount = amount;
    }

    public void Apply(Price price, Answer[] answers)
    {
        price.Amount += _amount;
    }
}