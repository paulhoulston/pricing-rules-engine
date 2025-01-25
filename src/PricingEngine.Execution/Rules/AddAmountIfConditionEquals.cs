namespace PricingEngine.Execution.Rules;

public class AddAmountIfConditionEquals<T> : IAmAPricingRule
{
    public void Apply(Price price, object answer)
    {
        if (typeof(T) == typeof(bool))
        {
            if ((bool)answer)
            {
                price.Amount += 10;
            }
        }
        else if (typeof(T) == typeof(int))
        {
            if ((int)answer == 5)
            {
                price.Amount += 25;
            }
        }
    }
}