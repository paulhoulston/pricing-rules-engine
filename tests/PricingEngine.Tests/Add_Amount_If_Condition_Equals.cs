using Xunit;
using PricingEngine.Execution;

namespace PricingEngine.Tests;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
public class Add_Amount_If_Condition_Equals
{
    PricingRulesExecutor _pricingEngine;
    PricingRulesExecutor.Price _price;
    
    public Add_Amount_If_Condition_Equals()
    {
        Given_that_I_have_a_pricing_engine_set_to_use_GBP();
        Given_there_is_a_rule_to_add_10_to_the_amount_if_the_answer_to_a_question_is_true();
        When_I_answer_the_question_with_true();
        Then_the_amount_is_increased_by_10();
    }
    
    void Given_that_I_have_a_pricing_engine_set_to_use_GBP()
    {
        _pricingEngine = new PricingRulesExecutor(PricingRulesExecutor.Currency.GBP);
    }

    void Given_there_is_a_rule_to_add_10_to_the_amount_if_the_answer_to_a_question_is_true()
    {
        _pricingEngine.AddRule(price =>
        {
            price.Amount += 10;
        });
    }

    void When_I_answer_the_question_with_true()
    {
        var answer = true;
        _price = _pricingEngine.GetPrice(true);
    }

    [Fact]
    void Then_the_amount_is_increased_by_10()
    {
        Assert.Equal(10, _price.Amount);

    }
}