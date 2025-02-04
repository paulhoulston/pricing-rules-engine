using Xunit;
using PricingEngine.Execution;
using PricingEngine.Execution.Rules;


namespace PricingEngine.Tests;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

public class Add_Fixed_Amount_To_Price
{
    PricingRulesExecutor _pricingEngine;
    Price _price;

    public Add_Fixed_Amount_To_Price()
    {
        Given_that_I_have_a_pricing_engine_set_to_use_GBP();
        Given_there_is_a_rule_to_add_20_to_the_amount();
        When_I_execute_the_pricing_rules();
        Then_the_amount_is_increased_by_20();
    }

    void Given_that_I_have_a_pricing_engine_set_to_use_GBP()
    {
        _pricingEngine = new PricingRulesExecutor(Currency.GBP);
    }

    void Given_there_is_a_rule_to_add_20_to_the_amount()
    {
        _pricingEngine.AddRule(new AddFixedAmount(20));
    }

    void When_I_execute_the_pricing_rules()
    {
        _price = _pricingEngine.CalculatePrice();
    }

    [Fact]
    void Then_the_amount_is_increased_by_20()
    {
        Assert.Equal(20, _price.Amount);
    }
}

