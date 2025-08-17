Console.WriteLine("Implementation of Singleton Logger (Not Thread Safe version)!");

var cart = new ShoppingCart();
var userService = new UserService();
var paymentService = new PaymentService();

userService.LoginUser("Buff Man");
cart.AddItem("Protein Bar");
paymentService.ProcessPayment(80m);

public class SingletonLogger
{
    private static SingletonLogger? _instance = null;
    
    private SingletonLogger()
    {
        Console.WriteLine("SingletonLogger instance created!");
    }
    
    public static SingletonLogger GetInstance()
    {
        _instance ??= new SingletonLogger();

        return _instance;
    }

    public void LogMessage(string message)
    {
        Console.WriteLine($"[Singleton] {DateTime.Now} : {message}");
    }
}

public class ShoppingCart
{
    private readonly SingletonLogger _logger = SingletonLogger.GetInstance();

    public void AddItem(string item)
    {
        _logger.LogMessage($"Item added: {item}");
    }
}

public class UserService
{
    private readonly SingletonLogger _logger = SingletonLogger.GetInstance();

    public void LoginUser(string username)
    {
        _logger.LogMessage($"Logging in user: {username}");
    }
}

public class PaymentService
{
    private readonly SingletonLogger _logger = SingletonLogger.GetInstance();
    
    public void ProcessPayment(decimal amount)
    {
        _logger.LogMessage($"Processing payment: {amount}");
    }
}