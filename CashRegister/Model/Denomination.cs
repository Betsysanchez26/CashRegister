namespace CashRegister.Model
{
    public class Denomination
    {
        public decimal NumericValue { get; set; }
        public int Count { get; set; }

        public Denomination(decimal numericValue, int count)
        {
            NumericValue = numericValue;
            Count = count;
        }
    }
}
