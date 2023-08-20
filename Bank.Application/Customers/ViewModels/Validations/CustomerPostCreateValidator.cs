using Bank.Application.Customers.Commands.CreateCustomer;
using Bank.Application.Interfaces;
using FluentValidation;

namespace Bank.Application.Customers.ViewModels.Validations
{
    public class CustomerPostCreateValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CustomerPostCreateValidator(IApplicationDbContext context)
        {
            RuleFor(m => m.ViewModel.Id).NotEqual(Guid.Empty);
            RuleFor(m => m.ViewModel.FirstName).Length(2, 20);
            RuleFor(m => m.ViewModel.LastName).Length(4, 50);
            RuleFor(m => m.ViewModel.FirstName).Length(4, 50);
            RuleFor(m => m.ViewModel.Passpost).Must(v => context.Customers.Any(m => m.Passport == v));
            RuleFor(m => m.ViewModel.Phone).Must(v => context.Customers.Any(m => m.Telephone == v));
        }
    }
}
