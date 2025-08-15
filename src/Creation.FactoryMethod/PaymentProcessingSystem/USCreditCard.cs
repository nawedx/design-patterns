namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class USCreditCard : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating with Visa/Mastercard");
    
    public void ProcessPayment(decimal amount, Currency currency) 
    {
        var convertedAmount = CurrencyConverter.Convert(amount, currency, Currency.USD);
        Console.WriteLine($"Processing ${convertedAmount:F2} USD via Stripe");
    }
    
    public void SendConfirmation() => Console.WriteLine("Sending SMS confirmation");
    public void HandleFailure() => Console.WriteLine("Handling US CreditCard failure");
    public decimal GetTransactionFee(decimal amount) => amount * 0.029m; // 2.9%
}