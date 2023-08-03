using Bank.Application.Base;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Domain.Base;
using System.Security.Claims;

namespace Bank.Application.Customers.Validations.RulesValidation
{
    public class TelephoneCustomerValidationRules : IValidationRules<CustomerPutUpdateViewModel>
    {
        public ValidationResult<CustomerPutUpdateViewModel> Validate(CustomerPutUpdateViewModel model, ClaimsPrincipal user)
        {
            if (model.FirstNameIsChanged)
            {
                if (user.Claims.Any(m => m.Value == AppData.TelephoneCustomerCanUpdate))
                {
                    return new ValidationResult<CustomerPutUpdateViewModel>
                    {
                        Model = model,
                        IsValid = true,
                        Description = "Success"
                    };
                }
                return new ValidationResult<CustomerPutUpdateViewModel>
                {
                    Model = model,
                    IsValid = false,
                    Description = "Not enough rights"
                };
            }
            return new ValidationResult<CustomerPutUpdateViewModel>
            {
                Model = model,
                IsValid = true,
                Description = "Not changed"
            };
        }
    }
}
