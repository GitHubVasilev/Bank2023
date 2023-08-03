using System.Security.Claims;
using Bank.Application.Base;

namespace Bank.Application.Interfaces
{
    public interface IValidationRules<T> where T : class
    {
        ValidationResult<T> Validate(T model, ClaimsPrincipal user);
    }
}
