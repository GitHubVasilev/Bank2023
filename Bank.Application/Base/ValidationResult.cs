namespace Bank.Application.Base
{
    public class ValidationResult<T>
        where T : class
    {
        public bool IsValid  => Description!.Count() > 0;

        public List<string> Description { get; set; } = new List<string>();

        public T Model { get; set; } = null!;
    }
}
