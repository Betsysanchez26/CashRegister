// See https://aka.ms/new-console-template for more information
using CashRegister;
using CashRegister.Currencies;
using CashRegister.Model;

//Define the current supported currencies
List<Currency> availableCurrencies = new()
{
    new USD(),
    new MXN()
};

//Get current country code
string currencyCode = GlobalCurrencyConfig.GetCurrency();

//Check if there is no currency code configured
if (String.IsNullOrEmpty(currencyCode))
{
    ValidationResult<string> codeValidationResult = new();
    Console.WriteLine("Enter current currency code:");

    while (!codeValidationResult.Valid)
    {
        currencyCode = Console.ReadLine();
        codeValidationResult = InputConverter.ConvertInputCountryCode(currencyCode, availableCurrencies);
        Console.WriteLine(codeValidationResult.Message);
    }
    currencyCode = codeValidationResult.Value;
    GlobalCurrencyConfig.AddCurrency(currencyCode);
}

Currency  currentCurrency = availableCurrencies.FirstOrDefault(c => c.CurrencyCode == currencyCode);

//Get amount to pay
ValidationResult<decimal> amountValidationResult = new();
while (!amountValidationResult.Valid)
{
    Console.WriteLine(String.IsNullOrEmpty(amountValidationResult.Message) ? "Enter the amount to pay:":$"{amountValidationResult.Message}Try again:");
    amountValidationResult = InputConverter.ConvertInputAmount(Console.ReadLine());
}

//Gets the number of bills/coins for each denomination
currentCurrency.Denominations.ForEach(d=> 
{
    ValidationResult<int> validationResult = new();
    while (!validationResult.Valid)
    {
        Console.WriteLine($"{validationResult.Message}How many {currentCurrency.Symbol}{d.NumericValue} are:");
        validationResult = InputConverter.ConvertInputDenomination(Console.ReadLine());
    }
    d.Count = validationResult.Value;
});

Result result = ReturnChange.CalculateReturnChange(amountValidationResult.Value, currentCurrency);
Console.WriteLine("\n"+result.Message);
if(result.Denominations.Count > 0)
{
    result.Denominations.ForEach(r=>
    {
        Console.WriteLine($"{r.Count} of {currentCurrency.Symbol}{r.NumericValue}");
    });
}
