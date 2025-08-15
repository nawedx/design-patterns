namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class AsiaPaymentProcessor : PaymentProcessor
{
    protected override IPaymentMethod CreatePaymentMethod(string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        return type.ToLower() switch
        {
            "digitalwallet" => new AsiaDigitalWallet(),
            "cryptocurrency" => new Cryptocurrency(),
            "banktransfer" => new BankTransfer(),
            _ => throw new ArgumentException($"{type} is not supported by AsiaPaymentProcessor"),
        };
    }
    
    public override Currency GetRegionCurrency() => Currency.CNY;
    public override List<string> GetSupportedMethods() => new() { "digitalwallet", "cryptocurrency", "banktransfer" };
    public override string GetRegionInfo() => "Asia Payment Processor";
}