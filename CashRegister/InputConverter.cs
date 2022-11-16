using CashRegister.Model;

namespace CashRegister
{
    public class InputConverter
    {
        /// <summary>
        /// Validate amount input. 
        /// </summary>
        /// <param name="input"></param>
        public static ValidationResult<decimal> ConvertInputAmount(string input)
        {
            decimal value;
            try
            {
                value = Convert.ToDecimal(input);
                if(value <= 0)
                {
                    return new ValidationResult<decimal>(false, "Zero or negative numbers are not allowed. ", value);
                }
                return new ValidationResult<decimal>(true, "Success", value);
            }
            catch (Exception)
            {
                value = 0;
                return new ValidationResult<decimal>(false, "Invalid value please enter a decimal. ", value);
            }
        }
        /// <summary>
        /// Validate denomination input. 
        /// </summary>
        /// <param name="input"></param>
        public static ValidationResult<int> ConvertInputDenomination(string input)
        {
            int value;
            try
            {
                bool isNullValue = String.IsNullOrEmpty(input);
                value = Convert.ToInt32(isNullValue ? 0 : input);
                if (value < 0)
                {
                    return new ValidationResult<int>(false, "Negative numbers are not allowed. ", value);
                }
                return new ValidationResult<int>(true, "Success", value);
            }
            catch (Exception)
            {
                value=0;
                return new ValidationResult<int>( false, "Invalid value please enter an integer. ", value);
            }
        }
        /// <summary>
        /// Validate country code input. 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="availableCurrencies"></param>
        public static ValidationResult<string> ConvertInputCountryCode(string input, List<Currency> availableCurrencies)
        {
            try
            {
                if (input.Length != 3)
                {
                    return new ValidationResult<string>(false, "Currency code must have 3 characters, try again.", "");
                }
                else
                {
                    input = input.ToUpper();
                    if (availableCurrencies.FirstOrDefault(c => c.CurrencyCode == input) != null)
                    {
                        return new ValidationResult<string>(true, $"Currency code {input} configured.", input);
                    }
                    else
                    {
                        var availableCurrencyCodes = string.Join(",", availableCurrencies.Select(c=> c.CurrencyCode)); ;
                        return new ValidationResult<string>(false, $"Currency code not available, try again. ({availableCurrencyCodes})", "");
                    }
                }
            }
            catch (Exception)
            {
                return new ValidationResult<string>(false, "Invalid value, try again.", "");
            }
        }
    }
}
