namespace PricingEngine.Execution.Rules;

public class AddAmountIfConditionEquals<T> : IAmAPricingRule
{
    readonly Parameters _parameters;

    public class Parameters
    {
        public T Condition { get; set; }
        public decimal AmountDelta { get; set; }
    }

    public AddAmountIfConditionEquals(Parameters parameters)
    {
        _parameters = parameters;
    }

    public void Apply(Price price, object answer)
    {
        if (answer.Equals(_parameters.Condition))
        {
            price.Amount += _parameters.AmountDelta;
        }
    }
}