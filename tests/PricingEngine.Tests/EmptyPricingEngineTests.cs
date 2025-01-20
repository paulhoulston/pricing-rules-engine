namespace PricingEngine.Tests;

public class EmptyPricingEngineTests
{
    private PricingRulesExecutor _pricingExecutor;

    private PricingRulesExecutor.Price _price;

    [Fact]
    public void Test_that_I_get_default_zero_price_when_no_rules_are_added()
    {
        Given_that_I_initialize_the_currency_to_GBP_and_assign_no_rules();
        When_I_execute_the_pricing_rules();
        Then_the_price_is_zero();
        Then_the_currency_is_GBP();
    }

    private void Given_that_I_initialize_the_currency_to_GBP_and_assign_no_rules()
    {
        _pricingExecutor = new PricingRulesExecutor(PricingRulesExecutor.Currency.GBP);
    }

    private void When_I_execute_the_pricing_rules()
    {
        _price = _pricingExecutor.GetPrice();
    }

    private void Then_the_price_is_zero()
    {
        Assert.Equal(0, _price.Amount);
    }

    private void Then_the_currency_is_GBP()
    {
        Assert.Equal(PricingRulesExecutor.Currency.GBP, _price.Currency);
    }
}

public class PricingRulesExecutor
{
    public enum Currency
    {
        GBP
    }

    public class Price
    {
        public int Amount { get; set; }
        public Currency Currency { get; set; }
    }

    readonly Currency _currency;

    public PricingRulesExecutor(Currency currency)
    {
        _currency = currency;
    }

    public Price GetPrice()
    {
        return new Price { Amount = 0, Currency = _currency };
    }
}
