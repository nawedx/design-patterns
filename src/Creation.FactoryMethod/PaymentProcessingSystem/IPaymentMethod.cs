namespace Creation.FactoryMethod.PaymentProcessingSystem;

public interface IPaymentMethod
{
    void ValidatePayment();

    void ProcessPayment(decimal amount, Currency currency);

    void SendConfirmation();

    void HandleFailure();
    
    decimal GetTransactionFee(decimal amount);
}