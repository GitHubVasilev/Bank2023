﻿using Bank.Application.Base;
using Bank.Application.Customers.Factories;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using System.Security.Claims;

namespace Bank.Application.Customers.Validations
{
    public class ValidatorCustomer : IValidator<CustomerPutUpdateViewModel>
    {
        private IEnumerable<IValidationRules<CustomerPutUpdateViewModel>> _validationRules;

        public ValidatorCustomer(IEnumerable<IValidationRules<CustomerPutUpdateViewModel>> rulesValidation)
        {
            _validationRules = rulesValidation;
        }

        public ValidationResult<CustomerPutUpdateViewModel> Validate(CustomerPutUpdateViewModel model, ClaimsPrincipal user)
        {
            ValidationResult<CustomerPutUpdateViewModel> validationResult = ValidateResultFactory.CreateValidationResult(model);
            foreach (var rule in _validationRules)
            {
                ValidationResult<CustomerPutUpdateViewModel> result = rule.Validate(model, user);
                if (!result.IsValid) 
                {
                    validationResult.Description.AddRange(result.Description);
                }
            }

            return validationResult;
        }
    }
}