using CashRegister;
using CashRegister.Currencies;
using CashRegister.Model;

namespace CashRegisterTest
{
    public class ProgramManagerTests
    {

        [Theory]
        [InlineData("-1")]
        [InlineData("0")]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData("f")]
        [InlineData(".")]
        [InlineData("1000000000000000000000000000000000000000")]
        public void ConverterInputAmount_InvalidEntries_ReturnFalse(string value)
        {
            var result = InputConverter.ConvertInputAmount(value);

            Assert.False(result.Valid);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData(" ")]
        [InlineData("f")]
        [InlineData(".")]
        [InlineData("1000000000000000000000000000000000000000")]
        public void ConvertInputDenomination_InvalidEntries_ReturnFalse(string value)
        {
            var result = InputConverter.ConvertInputDenomination(value);

            Assert.False(result.Valid);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData(" ")]
        [InlineData("f")]
        [InlineData("1000000000000000000000000000000000000000")]
        [InlineData("CAD")]
        public void ConvertInputCountryCode_InvalidEntries_ReturnFalse(string value)
        {
            List<Currency> availableCurrencies = new()
            {
                new USD(),
                new MXN()
            };
            var result = InputConverter.ConvertInputCountryCode(value, availableCurrencies);

            Assert.False(result.Valid);
        }
    }
}
