namespace Creation.FactoryMethod.PizzaOrderingSystem.PizzaOrderingSystemBad;

public class MargheritaPizza
{
	public void Prepare() => Console.WriteLine("Preparing Margherita");
	public void Bake() => Console.WriteLine("Baking Margherita");
}

public class PepperoniPizza
{
	public void Prepare() => Console.WriteLine("Preparing Pepperoni");
	public void Bake() => Console.WriteLine("Baking Pepperoni");
}

public class VeggiePizza
{
	public void Prepare() => Console.WriteLine("Preparing Veggie");
	public void Bake() => Console.WriteLine("Baking Veggie");
}

public class PizzaOrderingSystem
{
	public void OrderPizza(string pizzaType)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(pizzaType);

		if (pizzaType == "margherita")
		{
			var pizza = new MargheritaPizza();
			pizza.Prepare();
			pizza.Bake();
		}
		else if (pizzaType == "pepperoni")
		{
			var pizza = new PepperoniPizza();
			pizza.Prepare();
			pizza.Bake();
		}
		else if (pizzaType == "veggie")
		{
			var pizza = new VeggiePizza();
			pizza.Prepare();
			pizza.Bake();
		}
        else
        {
			Console.WriteLine("Sorry, we don't make that type of pizza");
        }
	}
}
