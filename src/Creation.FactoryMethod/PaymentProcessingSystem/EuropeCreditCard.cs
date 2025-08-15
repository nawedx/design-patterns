namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class EuropeCreditCard : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating with European banking standards");
    
    public void ProcessPayment(decimal amount, Currency currency)
    {
        var convertedAmount = CurrencyConverter.Convert(amount, currency, Currency.EUR);
        Console.WriteLine($"Processing €{convertedAmount:F2} EUR via European gateway");
    }
    
    public void SendConfirmation() => Console.WriteLine("Sending email confirmation");
    public void HandleFailure() => Console.WriteLine("Handling Europe CreditCard failure");
    public decimal GetTransactionFee(decimal amount) => amount * 0.025m; // 2.5%
}