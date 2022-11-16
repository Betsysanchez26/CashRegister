namespace CashRegister.Model
{
    public abstract class Currency
    {
        public string CurrencyCode { get; set; }
        public  List<Denomination> Denominations { get; set; }
        public string Symbol { get; set; }

        /// <summary>
        /// Set the denominations, currency code and symbol of a currency 
        /// </summary>
        /// <param name="denominations"></param>
        /// <param name="currencyCode"></param>
        /// <param name="symbol"></param>
        protected void SetCurrency(decimal[] denominations, string currencyCode, string symbol)
        {
            CurrencyCode = currencyCode;
            Symbol = symbol;
            Denominations = new List<Denomination>();
            denominations = denominations.OrderByDescending(v => v).ToArray();

            foreach (decimal d in denominations)
            {
                Denominations.Add(new Denomination(d, 0));
            }
        }
    }
}
