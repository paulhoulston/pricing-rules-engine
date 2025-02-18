namespace PricingEngine.Execution.Rules;

using PricingEngine.Execution;

public class AddAmountIfConditionEquals<T> : IAmAPricingRule
{
    readonly Parameters _parameters;

    public class Parameters
    {
        public int QuestionId { get; set; }
        public T Condition { get; set; }
        public decimal AmountDelta { get; set; }
    }

    public AddAmountIfConditionEquals(Parameters parameters)
    {
        _parameters = parameters;
    }

    public void Apply(Price price, Answer[] answers)
    {
        var answer = (T?)answers.SingleOrDefault(a => a.QuestionId == _parameters.QuestionId)?.Value;

        if (answer != null && ((T)answer).Equals(_parameters.Condition))
        {
            price.Amount += _parameters.AmountDelta;
        }
    }
}