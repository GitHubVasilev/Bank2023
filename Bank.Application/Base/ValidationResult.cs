namespace Bank.Application.Base
{
    public class ValidationResult<T>
        where T : class
    {
        public bool IsValid { get; set; }

        public string? Description { get; set; }

        public T Model { get; set; } = null!;
    }
}
