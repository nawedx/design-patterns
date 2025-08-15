## Challenge: Payment Processing System

**Scenario**: You're building a payment gateway that needs to handle different payment methods across different regions. Each region has its own preferred payment providers and processing rules.

**Requirements**:

1. **Payment Methods**: CreditCard, PayPal, BankTransfer, DigitalWallet, Cryptocurrency

2. **Each payment should have these methods**:
    - `ValidatePayment()` - Validate payment details
    - `ProcessPayment(decimal amount)` - Process the actual payment
    - `SendConfirmation()` - Send confirmation to user
    - `HandleFailure()` - Handle payment failures

3. **Regional Processors**:
    - `USPaymentProcessor` - Supports CreditCard, PayPal, DigitalWallet
    - `EuropePaymentProcessor` - Supports CreditCard, BankTransfer, PayPal
    - `AsiaPaymentProcessor` - Supports DigitalWallet, Cryptocurrency, BankTransfer
    - `UniversalPaymentProcessor` - Supports all payment types (premium service)

4. **Region-specific behaviors**:
    - **US CreditCard**: "Validating with Visa/Mastercard", "Processing via Stripe", "Sending SMS confirmation"
    - **Europe BankTransfer**: "Validating IBAN", "Processing via SEPA", "Sending email confirmation"
    - **Asia DigitalWallet**: "Validating with Alipay/WeChat", "Processing via local gateway", "Sending app notification"

5. **Advanced Requirements** 🔥:
    - Add a `GetTransactionFee(decimal amount)` method to each payment type
    - Each processor should have `GetSupportedMethods()` and `GetRegionInfo()`
    - Handle currency conversion (USD for US, EUR for Europe, CNY for Asia)
    - Add payment method priority (some methods are preferred in certain regions)

## What This Tests (Harder Than Before):

1. **Multiple Factory Hierarchies**: Different regions, different payment types
2. **Business Logic Integration**: Transaction fees, currency conversion
3. **Error Handling**: Unsupported payment methods in regions
4. **Extensibility**: Adding new regions or payment methods
5. **Real-world Complexity**: Region-specific behaviors and rules

## Your Challenge:

1. **Design the complete Factory Method pattern**
2. **Implement at least 3 regional processors**
3. **Show currency conversion working**
4. **Demonstrate adding a new region (like `MiddleEastPaymentProcessor`)** without changing existing code
5. **Add comprehensive error handling**

## Bonus Challenges 🚀:

- **Priority System**: Some payment methods should be tried first in certain regions
- **Fallback Logic**: If preferred method fails, try secondary methods
- **Transaction Logging**: Log all payment attempts with timestamps
- **Rate Limiting**: Some processors have daily transaction limits

## Example Usage You Should Support:

```csharp
// Should work like this:
var processor = new USPaymentProcessor();
var payment = processor.ProcessTransaction("creditcard", 100.50m);

var euroProcessor = new EuropePaymentProcessor();
var europeanPayment = euroProcessor.ProcessTransaction("banktransfer", 75.00m);

// Should handle errors gracefully:
var asiaProcessor = new AsiaPaymentProcessor();
// This should fail gracefully - Asia doesn't support PayPal
var invalidPayment = asiaProcessor.ProcessTransaction("paypal", 50.00m);
```

## Think About:

1. **What should be the factory method name?** (CreatePayment? BuildPaymentHandler?)
2. **Where should currency conversion logic go?** (In the processor or payment class?)
3. **How do you handle region-specific validation rules?**
4. **What's the best way to store supported payment methods per region?**

This is a more realistic, complex scenario. Take your time to think through the design before coding. The key is making sure your Factory Method pattern can handle:
- Multiple product families (payment types)
- Multiple factory types (regions)
- Complex business rules
- Easy extensibility

Try implementing this step by step and share your solution. I'm particularly interested in seeing how you handle the currency conversion and regional differences!

**Hint**: You might want to use enums for PaymentType and Currency, and consider where business logic (like fees) should live in your design.