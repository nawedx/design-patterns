namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class Cryptocurrency : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating crypto wallet address");
    public void ProcessPayment(decimal amount, Currency currency) => Console.WriteLine($"Processing crypto payment: {amount:F2} {currency}");
    public void SendConfirmation() => Console.WriteLine("Sending blockchain confirmation");
    public void HandleFailure() => Console.WriteLine("Handling crypto payment failure");
    public decimal GetTransactionFee(decimal amount) => amount * 0.01m; // 1%
}