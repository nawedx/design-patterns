namespace Creation.FactoryMethod.PaymentProcessingSystem;

public abstract class PaymentProcessor
{
    protected abstract IPaymentMethod CreatePaymentMethod(string type);
    public abstract Currency GetRegionCurrency();
    public abstract List<string> GetSupportedMethods();
    public abstract string GetRegionInfo();
    
    public IPaymentMethod ProcessTransaction(string type, decimal amount)
    {
        Console.WriteLine($"\n--- {GetRegionInfo()} Processing {type} ---");
        
        var paymentMethod = CreatePaymentMethod(type);
        var currency = GetRegionCurrency();
        
        paymentMethod.ValidatePayment();
        
        var fee = paymentMethod.GetTransactionFee(amount);
        var totalAmount = amount + fee;
        Console.WriteLine($"Transaction fee: {currency} {fee:F2}");
        Console.WriteLine($"Total amount: {currency} {totalAmount:F2}");
        
        paymentMethod.ProcessPayment(totalAmount, currency);
        paymentMethod.SendConfirmation();
        
        return paymentMethod;
    }
    
    public bool IsPaymentMethodSupported(string type)
    {
        return GetSupportedMethods().Contains(type.ToLower());
    }
}