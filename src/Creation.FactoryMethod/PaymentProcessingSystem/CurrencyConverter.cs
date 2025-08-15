namespace Creation.FactoryMethod.PaymentProcessingSystem;

public static class CurrencyConverter
{
    private static readonly Dictionary<(Currency from, Currency to), decimal> ExchangeRates = new()
    {
        { (Currency.USD, Currency.EUR), 0.85m },
        { (Currency.USD, Currency.CNY), 7.2m },
        { (Currency.EUR, Currency.USD), 1.18m },
        { (Currency.EUR, Currency.CNY), 8.5m },
        { (Currency.CNY, Currency.USD), 0.14m },
        { (Currency.CNY, Currency.EUR), 0.12m }
    };
    
    public static decimal Convert(decimal amount, Currency from, Currency to)
    {
        if (from == to) return amount;
        
        if (ExchangeRates.TryGetValue((from, to), out decimal rate))
        {
            return amount * rate;
        }
        
        throw new NotSupportedException($"Conversion from {from} to {to} not supported");
    }
}