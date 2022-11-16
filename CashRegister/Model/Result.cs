namespace CashRegister.Model
{
    public class Result
    {
        public string Message { get; set; }
        public List<Denomination> Denominations { get; set; }
        public Result(string message, List<Denomination> denominations)
        {
            Message = message;
            Denominations = denominations;
        }
    }
}
