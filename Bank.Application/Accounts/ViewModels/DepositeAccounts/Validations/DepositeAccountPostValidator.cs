using Bank.Application.Accounts.Commands.CreateAccount;
using FluentValidation;

namespace Bank.Application.Accounts.ViewModels.DepositeAccounts.Validations
{
    public class DepositeAccountPostValidator : AbstractValidator<CreateDepositeAccountCommand>
    {
        public DepositeAccountPostValidator()
        {
            RuleFor(m => m.ViewModel.UID).NotEmpty();
            RuleFor(m => m.ViewModel.Name).Length(5, 20);
            RuleFor(m => m.ViewModel.ClientId).NotEmpty();
            RuleFor(m => m.ViewModel.Procent).GreaterThanOrEqualTo(0);
        }
    }
}
