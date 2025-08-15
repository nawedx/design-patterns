namespace Creation.FactoryMethod.PaymentProcessingSystem;

public class EuropeBankTransfer : IPaymentMethod
{
    public void ValidatePayment() => Console.WriteLine("Validating IBAN");
    
    public void ProcessPayment(decimal amount, Currency currency)
    {
        var convertedAmount = CurrencyConverter.Convert(amount, currency, Currency.EUR);
        Console.WriteLine($"Processing €{convertedAmount:F2} EUR via SEPA");
    }
    
    public void SendConfirmation() => Console.WriteLine("Sending email confirmation");
    public void HandleFailure() => Console.WriteLine("Handling Europe BankTransfer failure");
    public decimal GetTransactionFee(decimal amount) => 1.50m; // Fixed fee
}