namespace PricingEngine.Tests;

public class EmptyPricingEngineTests
{
    [Fact]
    public void Test_that_I_get_default_zero_price_when_no_rules_are_added()
    {
        var price = 0;
        var pricingExecutor = new PricingRulesExecutor();
        price = pricingExecutor.GetPrice();
        Assert.Equal(0, price);
    }
}

public class PricingRulesExecutor
{
    public int GetPrice()
    {
        return 0;
    }
}
