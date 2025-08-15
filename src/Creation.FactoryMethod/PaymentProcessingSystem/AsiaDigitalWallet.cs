namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class AsiaDigitalWallet : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating with Alipay/WeChat");
    
    public void ProcessPayment(decimal amount, Currency currency)
    {
        var convertedAmount = CurrencyConverter.Convert(amount, currency, Currency.CNY);
        Console.WriteLine($"Processing ¥{convertedAmount:F2} CNY via local gateway");
    }
    
    public void SendConfirmation() => Console.WriteLine("Sending app notification");
    public void HandleFailure() => Console.WriteLine("Handling Asia DigitalWallet failure");
    public decimal GetTransactionFee(decimal amount) => amount * 0.015m; // 1.5%
}