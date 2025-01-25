namespace PricingEngine.Execution.Rules;

public class AddAmountIfConditionEquals : IAmAPricingRule
{
    public void Apply(Price price, bool answer)
    {
        if (answer)
        {
            price.Amount += 10;
        }
    }
}