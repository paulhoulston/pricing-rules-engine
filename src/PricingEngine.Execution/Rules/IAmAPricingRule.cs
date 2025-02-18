namespace PricingEngine.Execution.Rules;

using PricingEngine.Execution;

public interface IAmAPricingRule
{
    void Apply(Price price, Answer[] answers);
}
