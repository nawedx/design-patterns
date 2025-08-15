using Creation.FactoryMethod.PizzaOrderingSystem.PizzaOrderingSystemGood;
using Xunit;
using Xunit.Abstractions;

namespace Creation.FactoryMethod.Tests.PizzaOrderingSystemGoodTests;

public class PizzaOrderingSystemTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PizzaOrderingSystemTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper ?? throw new ArgumentNullException(nameof(testOutputHelper));
    }

    [Fact]
    public void MustOrderPizza()
    {
        var pizzaOrderingSystem =
            new PizzaOrderingSystem.PizzaOrderingSystemGood.PizzaOrderingSystem(new AmericanPizzaStore());

        var pepperoniPizza = pizzaOrderingSystem.OrderPizza("pepperoni");
        var veggiePizza = pizzaOrderingSystem.OrderPizza("veggie");

        Assert.Equal("pepperoni", pepperoniPizza.Get());
        Assert.Equal("veggie", veggiePizza.Get());

        _testOutputHelper.WriteLine(pepperoniPizza.Get());
        _testOutputHelper.WriteLine(veggiePizza.Get());
    }
}