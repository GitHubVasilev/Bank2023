﻿using Bank.Application.Base;
using Bank.Application.Customers.Factories;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Domain.Base;
using System.Security.Claims;

namespace Bank.Application.Customers.Validations.RulesValidation
{
    public class PassportCustomerValidationRules : IValidationRules<CustomerPutUpdateViewModel>
    {
        public ValidationResult<CustomerPutUpdateViewModel> Validate(CustomerPutUpdateViewModel model, ClaimsPrincipal user)
        {
            ValidationResult<CustomerPutUpdateViewModel> validationResult = ValidateResultFactory.CreateValidationResult(model);
            if (model.PassportIsChanged)
            {
                if (user.Claims.Any(m => m.Value == AppData.PassportCustomerCanUpdate))
                {
                    return validationResult;
                }
                validationResult.Description.Add("Not enough rights");
                return validationResult;
            }
            return validationResult;
        }
    }
}