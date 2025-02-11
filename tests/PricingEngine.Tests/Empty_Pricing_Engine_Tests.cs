﻿using PricingEngine.Execution;
using PricingEngine.Execution.Rules;

namespace PricingEngine.Tests;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

public class Price_is_set_to_zero_and_specified_currency_when_no_rules_are_added
{
    private PricingRulesExecutor _pricingExecutor;
    private Price _price;

    public Price_is_set_to_zero_and_specified_currency_when_no_rules_are_added()
    {
        Given_that_I_initialize_the_currency_to_GBP_and_assign_no_rules();
        When_I_execute_the_pricing_rules();
        Then_the_price_is_zero();
        Then_the_currency_is_GBP();
    }

    private void Given_that_I_initialize_the_currency_to_GBP_and_assign_no_rules()
    {
        _pricingExecutor = new PricingRulesExecutor(Currency.GBP);
    }

    private void When_I_execute_the_pricing_rules()
    {
        _price = _pricingExecutor.CalculatePrice();
    }

    [Fact]
    private void Then_the_price_is_zero()
    {
        Assert.Equal(0, _price.Amount);
    }

    [Fact]
    private void Then_the_currency_is_GBP()
    {
        Assert.Equal(Currency.GBP, _price.Currency);
    }
}
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
#pragma warning restore CS8602 // Dereference of a possibly null reference.

