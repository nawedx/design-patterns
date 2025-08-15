namespace Creation.FactoryMethod.PizzaOrderingSystemGood;

public class PizzaOrderingSystem
{
    private readonly PizzaStore _store;

    public PizzaOrderingSystem(PizzaStore store)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
    }

    public IPizza OrderPizza(string type)
    {
        var pizza = _store.OrderPizza(type);

        return pizza;
    }
}

public class ItalianPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "margherita" => new MargheritaPizza(),
            "veggie" => new VeggiePizza(),
            _ => throw new ArgumentException($"We don't have {type} pizza")
        };
    }
}

public class AmericanPizzaStore : PizzaStore
{
    protected override IPizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "pepperoni" => new PepperoniPizza(),
            "veggie" => new VeggiePizza(),
            _ => throw new ArgumentException($"We don't have {type} pizza")
        };
    }
}

public abstract class PizzaStore
{
    protected abstract IPizza CreatePizza(string type);

    public IPizza OrderPizza(string type)
    {
        var pizza = CreatePizza(type);
        
        pizza.Prepare();
        pizza.Bake();
        
        Console.WriteLine($"Your {type} pizza is ready");
        return pizza;
    }
}

public interface IPizza
{
    void Prepare();
    void Bake();
    string Get();
}

public class MargheritaPizza : IPizza
{
    private const string PizzaType = "margherita";
    public void Prepare() => Console.WriteLine("Preparing Margherita");
    public void Bake() => Console.WriteLine("Baking Margherita");
    
    public string Get() => PizzaType;
}

public class PepperoniPizza : IPizza
{
    private const string PizzaType = "pepperoni";
    public void Prepare() => Console.WriteLine("Preparing Pepperoni");
    public void Bake() => Console.WriteLine("Baking Pepperoni");
    public string Get() => PizzaType;
}

public class VeggiePizza : IPizza
{
    private const string PizzaType = "veggie";
    public void Prepare() => Console.WriteLine("Preparing Veggie");
    public void Bake() => Console.WriteLine("Baking Veggie");
    public string Get() => PizzaType;
}