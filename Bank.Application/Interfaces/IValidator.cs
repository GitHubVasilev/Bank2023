using System.Security.Claims;
using Bank.Application.Base;

namespace Bank.Application.Interfaces
{
    public interface IValidator<T> where T : class
    {
        public ValidationResult<T> Validate(T model, ClaimsPrincipal user);
    }
}
