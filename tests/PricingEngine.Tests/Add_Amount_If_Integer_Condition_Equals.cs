using Xunit;
using PricingEngine.Execution;
using PricingEngine.Execution.Rules;

namespace PricingEngine.Tests;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
public class Add_Amount_If_Integer_Condition_Equality_Is_Matched
{
    readonly Guid _questionId1 = Guid.NewGuid();
    PricingRulesExecutor _pricingEngine;
    Price _price;

    public Add_Amount_If_Integer_Condition_Equality_Is_Matched()
    {
        Given_that_I_have_a_pricing_engine_set_to_use_GBP();
        Given_there_is_a_rule_to_add_25_to_the_amount_if_the_answer_to_a_question_is_5();
        When_I_answer_the_question_with_5();
        Then_the_amount_is_increased_by_25();
    }

    void Given_that_I_have_a_pricing_engine_set_to_use_GBP()
    {
        _pricingEngine = new PricingRulesExecutor(Currency.GBP);
    }

    void Given_there_is_a_rule_to_add_25_to_the_amount_if_the_answer_to_a_question_is_5()
    {
        _pricingEngine.AddRule(new AddAmountIfConditionEquals<int>(new AddAmountIfConditionEquals<int>.Parameters
        {
            QuestionId = _questionId1,
            Condition = 5,
            AmountDelta = 25
        }));
    }

    void When_I_answer_the_question_with_5()
    {
        _price = _pricingEngine.CalculatePrice(new Answer(_questionId1, 5));
    }

    [Fact]
    void Then_the_amount_is_increased_by_25()
    {
        Assert.Equal(25, _price.Amount);

    }
}

public class Dont_Add_Amount_If_Integer_Condition_Equality_Is_Not_Matched
{
    readonly Guid _questionId1 = Guid.NewGuid();

    PricingRulesExecutor _pricingEngine;
    Price _price;

    public Dont_Add_Amount_If_Integer_Condition_Equality_Is_Not_Matched()
    {
        Given_that_I_have_a_pricing_engine_set_to_use_GBP();
        Given_there_is_a_rule_to_add_25_to_the_amount_if_the_answer_to_a_question_is_5();
        When_I_answer_the_question_with_an_answer_other_than_5();
        Then_the_amount_is_unchanged();
    }

    void Given_that_I_have_a_pricing_engine_set_to_use_GBP()
    {
        _pricingEngine = new PricingRulesExecutor(Currency.GBP);
    }

    void Given_there_is_a_rule_to_add_25_to_the_amount_if_the_answer_to_a_question_is_5()
    {
        _pricingEngine.AddRule(new AddAmountIfConditionEquals<int>(new AddAmountIfConditionEquals<int>.Parameters
        {
            QuestionId = _questionId1,
            Condition = 5,
            AmountDelta = 25
        }));
    }

    void When_I_answer_the_question_with_an_answer_other_than_5()
    {
        _price = _pricingEngine.CalculatePrice(new Answer(_questionId1, 4));
    }

    [Fact]
    void Then_the_amount_is_unchanged()
    {
        Assert.Equal(0, _price.Amount);
    }
}

