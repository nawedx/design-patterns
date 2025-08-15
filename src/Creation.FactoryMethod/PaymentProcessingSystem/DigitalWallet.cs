namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class DigitalWallet : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating digital wallet");
    public void ProcessPayment(decimal amount, Currency currency) => Console.WriteLine($"Processing digital wallet payment: {amount:F2} {currency}");
    public void SendConfirmation() => Console.WriteLine("Sending digital wallet notification");
    public void HandleFailure() => Console.WriteLine("Handling digital wallet failure");
    public decimal GetTransactionFee(decimal amount) => amount * 0.02m; // 2%
}