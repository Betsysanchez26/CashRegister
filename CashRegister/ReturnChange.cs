using CashRegister.Model;

namespace CashRegister
{
    public class ReturnChange
    {
        /// <summary>
        /// Calculate the optimal return change. 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        public static Result CalculateReturnChange(decimal amount, Currency currency)
        {
            decimal total = CalculateGivenAmount(currency.Denominations);
            List<Denomination> result = new List<Denomination>();
            //Check if the given money is enough to pay
            if (total < amount)
            {
                return new Result(Constants.NotEnoughMoneyMessage, new List<Denomination>());
            }
            // Check if the given money was the exact amount to pay
            else if (total == amount)
            {
                return new Result(Constants.ExactAmountMessage, new List<Denomination>());
            }
            else
            {
                decimal change = total - amount;
                string resultMessage = $"Total amount of change: {currency.Symbol}{change}";
                int i = 0;
                //Evaluate the optimal denominations to return the change
                while (change != 0)
                {
                    Denomination current = currency.Denominations[i];
                    if (change >= current.NumericValue)
                    {
                        decimal denomination = current.NumericValue;
                        int number = (int)(change / denomination);
                        change %= denomination;
                        result.Add(new Denomination(current.NumericValue, number));
                    }
                    i++;
                }
                return new Result(resultMessage, result);
            }
        }
        /// <summary>
        /// Calculate the given amount based on the number of items provided of each denomination
        /// </summary>
        /// <param name="currentCurrency"></param>
        private static decimal CalculateGivenAmount(List<Denomination> currentCurrency)
        {
            decimal totalAmount = 0;
            currentCurrency.ForEach(c =>
                totalAmount += c.NumericValue * c.Count
            );
            return totalAmount;
        }
    }
}
