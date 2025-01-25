namespace PricingEngine.Execution.Rules;

public interface IAmAPricingRule
{
    void Apply(Price price, bool answer);
}
