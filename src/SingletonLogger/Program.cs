Console.WriteLine("Implementation of Singleton Logger (Not Thread Safe version)!");

var cart = new ShoppingCart();
var userService = new UserService();
var paymentService = new PaymentService();

userService.LoginUser("Buff Man");
cart.AddItem("Protein Bar");
paymentService.ProcessPayment(80m);

// Test 1: Modern Singleton (Recommended)
Console.WriteLine("1. Testing Modern Singleton (Lazy<T>):");
TestModernSingleton();
        
// Test 2: Thread-Safe Singleton
Console.WriteLine("\n2. Testing Thread-Safe Singleton:");
TestThreadSafeSingleton();
        
// Test 3: Real-world example
Console.WriteLine("\n3. Testing Configuration Manager:");
TestConfigurationManager();
        
// Test 4: Prove they're the same instance
Console.WriteLine("\n4. Proving Same Instance:");
ProveInstanceSameness();

static void TestModernSingleton()
    {
        var tasks = new List<Task<ModernSingleton>>();
        
        // Create 10 tasks that all try to get the singleton
        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(() => ModernSingleton.Instance));
        }
        
        var results = Task.WhenAll(tasks).Result;
        
        // Check if all results are the same instance
        bool allSame = results.All(instance => ReferenceEquals(instance, results[0]));
        Console.WriteLine($"All 10 threaded instances are the same: {allSame}");
    }
    
    static void TestThreadSafeSingleton()
    {
        var instances = new List<ThreadSafeSingleton>();
        var tasks = new List<Task>();
        
        for (int i = 0; i < 5; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                var instance = ThreadSafeSingleton.GetInstance();
                lock (instances)
                {
                    instances.Add(instance);
                }
            }));
        }
        
        Task.WaitAll(tasks.ToArray());
        
        bool allSame = instances.All(instance => ReferenceEquals(instance, instances[0]));
        Console.WriteLine($"All 5 threaded instances are the same: {allSame}");
    }
    
    static void TestConfigurationManager()
    {
        // First access - will create the instance
        var config1 = ConfigurationManager.Instance;
        config1.DisplayAllSettings();
        
        // Second access - should get the same instance
        var config2 = ConfigurationManager.Instance;
        config2.SetSetting("NewSetting", "NewValue");
        
        // Third access - should see the new setting
        var config3 = ConfigurationManager.Instance;
        Console.WriteLine($"New setting from different reference: {config3.GetSetting("NewSetting")}");
        
        Console.WriteLine($"All config managers are same instance: {ReferenceEquals(config1, config2) && ReferenceEquals(config2, config3)}");
    }
    
    static void ProveInstanceSameness()
    {
        var modern1 = ModernSingleton.Instance;
        var modern2 = ModernSingleton.Instance;
        
        var threadSafe1 = ThreadSafeSingleton.GetInstance();
        var threadSafe2 = ThreadSafeSingleton.GetInstance();
        
        var eager1 = EagerSingleton.Instance;
        var eager2 = EagerSingleton.Instance;
        
        Console.WriteLine($"Modern Singleton same instance: {ReferenceEquals(modern1, modern2)}");
        Console.WriteLine($"Thread-Safe Singleton same instance: {ReferenceEquals(threadSafe1, threadSafe2)}");
        Console.WriteLine($"Eager Singleton same instance: {ReferenceEquals(eager1, eager2)}");
    }

public class BrokenSingletonLogger
{
    private static BrokenSingletonLogger? _instance = null;
    
    private BrokenSingletonLogger()
    {
        Console.WriteLine("SingletonLogger instance created!");
    }
    
    public static BrokenSingletonLogger GetInstance()
    {
        _instance ??= new BrokenSingletonLogger();

        return _instance;
    }

    public void LogMessage(string message)
    {
        Console.WriteLine($"[Singleton] {DateTime.Now} : {message}");
    }
}

public class ThreadSafeSingleton
{
    private static volatile ThreadSafeSingleton? _instance = null;
    private static readonly object _lock = new();

    private ThreadSafeSingleton()
    {
        Console.WriteLine("ThreadSafeSingleton created!");
    }
    
    public static ThreadSafeSingleton GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new ThreadSafeSingleton();
            }
        }
        
        return _instance;
    }

    public void DoWork()
    {
        Console.WriteLine($"ThreadSafeSingleton is working...");
    }
}

public class ModernSingleton
{
    private static readonly Lazy<ModernSingleton> _lazy = new Lazy<ModernSingleton>(() => new ModernSingleton());

    private ModernSingleton()
    {
        Console.WriteLine("ModernSingleton created!");
    }

    public static ModernSingleton Instance => _lazy.Value;

    public void DoWork()
    {
        Console.WriteLine($"ModernSingleton is working...");
    }
}

public class EagerSingleton
{
    private static readonly EagerSingleton _instance = new EagerSingleton();

    private EagerSingleton()
    {
        Console.WriteLine("EagerSingleton created!");
    }

    public static EagerSingleton Instance => _instance;

    public void DoWork()
    {
        Console.WriteLine($"EagerSingleton is working...");
    }
}

public class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> _lazy =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());

    private readonly Dictionary<string, string> _settings;

    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>
        {
            { "DatabaseConnection", "Server=localhost;Database=MyApp;" },
            { "ApiUrl", "https://api.myapp.com" },
            { "LogLevel", "Info" },
            { "MaxRetries", "3" }
        };
        Console.WriteLine("Configuration loaded!");
    }
    
    public static ConfigurationManager Instance => _lazy.Value;
    
    public string GetSetting(string key)
    {
        if (_settings.TryGetValue(key, out string value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Setting '{key}' not found");
    }
    
    public void SetSetting(string key, string value)
    {
        _settings[key] = value;
        Console.WriteLine($"Setting updated: {key} = {value}");
    }
    
    public void DisplayAllSettings()
    {
        Console.WriteLine("Current Configuration:");
        foreach (var setting in _settings)
        {
            Console.WriteLine($"  {setting.Key}: {setting.Value}");
        }
    }
}

public class ShoppingCart
{
    private readonly BrokenSingletonLogger _logger = BrokenSingletonLogger.GetInstance();

    public void AddItem(string item)
    {
        _logger.LogMessage($"Item added: {item}");
    }
}

public class UserService
{
    private readonly BrokenSingletonLogger _logger = BrokenSingletonLogger.GetInstance();

    public void LoginUser(string username)
    {
        _logger.LogMessage($"Logging in user: {username}");
    }
}

public class PaymentService
{
    private readonly BrokenSingletonLogger _logger = BrokenSingletonLogger.GetInstance();
    
    public void ProcessPayment(decimal amount)
    {
        _logger.LogMessage($"Processing payment: {amount}");
    }
}