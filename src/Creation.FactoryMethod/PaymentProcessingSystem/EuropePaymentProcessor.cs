namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class EuropePaymentProcessor : PaymentProcessor
{
    protected override IPaymentMethod CreatePaymentMethod(string type)
    {
        ArgumentException.ThrowIfNullOrEmpty(type);

        return type.ToLower() switch
        {
            "creditcard" => new EuropeCreditCard(),
            "banktransfer" => new EuropeBankTransfer(),
            "paypal" => new PayPal(),
            _ => throw new ArgumentException($"{type} is not supported by EuropePaymentProcessor"),
        };
    }
    
    public override Currency GetRegionCurrency() => Currency.EUR;
    public override List<string> GetSupportedMethods() => new() { "creditcard", "banktransfer", "paypal" };
    public override string GetRegionInfo() => "European Payment Processor";
}