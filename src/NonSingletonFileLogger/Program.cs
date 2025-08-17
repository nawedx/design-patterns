Console.WriteLine("Multiple Logger Instances");

var cart = new ShoppingCart();
var userService = new UserService();
var paymentService = new PaymentService();

userService.LoginUser("Buff Man");
cart.AddItem("Protein Bar");
paymentService.ProcessPayment(80m);

public class FileLogger
{
    private readonly string _filePath;
    private static int _instanceCount = 0;

    public FileLogger()
    {
        _instanceCount++;
        _filePath = "application.log";
        Console.WriteLine($"Logger instance #{_instanceCount} created!");
    }
    
    public void LogMessage(string message)
    {
        Console.WriteLine($"[Logger #{_instanceCount}] {DateTime.Now} : {message}");
    }
}

public class ShoppingCart
{
    private readonly FileLogger _logger = new();

    public void AddItem(string item)
    {
        _logger.LogMessage($"Item added: {item}");
    }
}

public class UserService
{
    private readonly FileLogger _logger = new();

    public void LoginUser(string username)
    {
        _logger.LogMessage($"Logging in user: {username}");
    }
}

public class PaymentService
{
    private readonly FileLogger _logger = new();
    
    public void ProcessPayment(decimal amount)
    {
        _logger.LogMessage($"Processing payment: {amount}");
    }
}