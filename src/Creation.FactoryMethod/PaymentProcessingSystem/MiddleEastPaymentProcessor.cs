namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class MiddleEastPaymentProcessor : PaymentProcessor
{
    protected override IPaymentMethod CreatePaymentMethod(string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        return type.ToLower() switch
        {
            "creditcard" => new USCreditCard(), // Reusing existing implementation
            "banktransfer" => new BankTransfer(),
            "digitalwallet" => new DigitalWallet(),
            _ => throw new ArgumentException($"{type} is not supported by MiddleEastPaymentProcessor"),
        };
    }
    
    public override Currency GetRegionCurrency() => Currency.USD; // Many ME countries use USD
    public override List<string> GetSupportedMethods() => new() { "creditcard", "banktransfer", "digitalwallet" };
    public override string GetRegionInfo() => "Middle East Payment Processor";
}