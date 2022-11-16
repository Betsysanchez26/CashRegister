namespace CashRegister.Model
{
    public class ValidationResult<T>
    {
        public string? Message { get; set; }
        public bool Valid { get; set; }
        public T? Value { get; set; }

        public ValidationResult(bool valid, string? message,  T? value )
        {
           Message = message;
           Valid = valid;
           Value = value;
        }

        public ValidationResult()
        {

        }
    }
}
