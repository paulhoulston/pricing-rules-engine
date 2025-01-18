namespace PricingEngine.Tests;

public class EmptyPricingEngineTests
{
    private PricingRulesExecutor _pricingExecutor;
    private int _price;
    
    [Fact]
    public void Test_that_I_get_default_zero_price_when_no_rules_are_added()
    {
        Given_no_rules_are_added();
        When_I_execute_the_pricing_rules();
        Then_the_price_is_zero();
    }

    private void Given_no_rules_are_added()
    {
        _pricingExecutor = new PricingRulesExecutor();
    }

    private void When_I_execute_the_pricing_rules()
    {
        _price = _pricingExecutor.GetPrice();
    }

    private void Then_the_price_is_zero()
    {
        Assert.Equal(0, _price);
    }
}

public class PricingRulesExecutor
{
    public int GetPrice()
    {
        return 0;
    }
}
