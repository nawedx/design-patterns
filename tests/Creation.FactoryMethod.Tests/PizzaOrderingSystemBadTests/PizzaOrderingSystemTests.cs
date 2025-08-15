using Xunit;

namespace Creation.FactoryMethod.Tests.PizzaOrderingSystemBadTests;

public class PizzaOrderingSystemTests
{
    [Fact]
    public void MustCreateDifferentKindsOfPizza()
    {
        var pizzaOrderingSystem = new PizzaOrderingSystem.PizzaOrderingSystemBad.PizzaOrderingSystem();
        
        pizzaOrderingSystem.OrderPizza("margherita");
        
        pizzaOrderingSystem.OrderPizza("pepperoni");
        
        pizzaOrderingSystem.OrderPizza("veggie");
    }
}