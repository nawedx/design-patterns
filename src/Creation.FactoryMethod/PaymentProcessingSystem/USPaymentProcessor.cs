namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class USPaymentProcessor : PaymentProcessor
{
    protected override IPaymentMethod CreatePaymentMethod(string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        return type.ToLower() switch
        {
            "creditcard" => new USCreditCard(),
            "paypal" => new PayPal(),
            "digitalwallet" => new DigitalWallet(),
            _ => throw new ArgumentException($"{type} is not supported by USPaymentProcessor"),
        };
    }
    
    public override Currency GetRegionCurrency() => Currency.USD;
    public override List<string> GetSupportedMethods() => new() { "creditcard", "paypal", "digitalwallet" };
    public override string GetRegionInfo() => "United States Payment Processor";
}