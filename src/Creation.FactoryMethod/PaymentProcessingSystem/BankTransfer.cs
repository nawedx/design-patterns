namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class BankTransfer : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating bank account details");
    public void ProcessPayment(decimal amount, Currency currency) => Console.WriteLine($"Processing bank transfer: {amount:F2} {currency}");
    public void SendConfirmation() => Console.WriteLine("Sending bank transfer confirmation");
    public void HandleFailure() => Console.WriteLine("Handling bank transfer failure");
    public decimal GetTransactionFee(decimal amount) => 2.00m; // Fixed fee
}