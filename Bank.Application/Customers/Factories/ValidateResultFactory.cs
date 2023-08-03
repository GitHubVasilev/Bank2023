using Bank.Application.Base;

namespace Bank.Application.Customers.Factories
{
    public static class ValidateResultFactory
    {
        public static ValidationResult<T> CreateValidationResult<T>(T model, bool isValid, string Description)
            where T : class
        {
            return new ValidationResult<T>()
            {
                Model = model,
                Description = Description,
                IsValid = isValid
            };
        }
    }
}
