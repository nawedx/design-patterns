namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class PayPal : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating PayPal account");
    public void ProcessPayment(decimal amount, Currency currency) => Console.WriteLine($"Processing PayPal payment: {amount:F2} {currency}");
    public void SendConfirmation() => Console.WriteLine("Sending PayPal email confirmation");
    public void HandleFailure() => Console.WriteLine("Handling PayPal failure");
    public decimal GetTransactionFee(decimal amount) => amount * 0.034m; // 3.4%
}