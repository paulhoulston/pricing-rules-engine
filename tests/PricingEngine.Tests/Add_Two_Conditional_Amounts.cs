using Xunit;
using PricingEngine.Execution;
using PricingEngine.Execution.Rules;


namespace PricingEngine.Tests;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

public class Add_Two_Conditional_Amounts
{
    readonly Guid _questionId1 = Guid.NewGuid();
    readonly Guid _questionId2 = Guid.NewGuid();

    PricingRulesExecutor _pricingEngine;
    Price _price;


    public Add_Two_Conditional_Amounts()
    {
        Given_that_I_have_a_pricing_engine_set_to_use_GBP();
        Given_there_is_a_rule_to_add_10_to_the_amount_if_the_answer_to_question_1_is_true();
        Given_there_is_a_rule_to_add_25_to_the_amount_if_the_answer_to_question_2_is_5();

        When_I_answer_the_question_1_with_true_AND_I_answer_the_question_2_with_5();

        Then_the_total_amount_is_35();
    }

    void Given_that_I_have_a_pricing_engine_set_to_use_GBP()
    {
        _pricingEngine = new PricingRulesExecutor(Currency.GBP);
    }

    void Given_there_is_a_rule_to_add_10_to_the_amount_if_the_answer_to_question_1_is_true()
    {
        _pricingEngine.AddRule(new AddAmountIfConditionEquals<bool>(new AddAmountIfConditionEquals<bool>.Parameters
        {
            QuestionId = _questionId1,
            Condition = true,
            AmountDelta = 10
        }));
    }

    void Given_there_is_a_rule_to_add_25_to_the_amount_if_the_answer_to_question_2_is_5()
    {
        _pricingEngine.AddRule(new AddAmountIfConditionEquals<int>(new AddAmountIfConditionEquals<int>.Parameters
        {
            QuestionId = _questionId2,
            Condition = 5,
            AmountDelta = 25
        }));

    }
    void When_I_answer_the_question_1_with_true_AND_I_answer_the_question_2_with_5()
    {
        _price = _pricingEngine.CalculatePrice(
            new Answer(_questionId1, true),
            new Answer(_questionId2, 5));
    }

    [Fact]
    void Then_the_total_amount_is_35()
    {
        Assert.Equal(35, _price.Amount);

    }

}