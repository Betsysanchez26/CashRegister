using CashRegister.Model;

namespace CashRegister.Currencies
{
    public class USD : Currency
    {
        public USD()
        {
            SetCurrency(new decimal[] { 100.00m, 50.00m, 20.00m, 10.00m, 5.00m, 2.00m, 1.00m, 0.50m, 0.25m, 0.10m, 0.05m, 0.01m}, "USD", "$");
        }
    }
}
