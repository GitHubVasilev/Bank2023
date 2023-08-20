using Bank.Application.Accounts.Commands.CreateAccount;
using FluentValidation;

namespace Bank.Application.Accounts.ViewModels.NoDepositeAccounts.Validations
{
    public class NoDepositeAccountPostValidator : AbstractValidator<CreateNoDepositeAccountCommand>
    {
        public NoDepositeAccountPostValidator()
        {
            RuleFor(m => m.viewModel.UID).NotEmpty();
            RuleFor(m => m.viewModel.Name).Length(5, 20);
            RuleFor(m => m.viewModel.ClientId).NotEmpty();
            RuleFor(m => m.viewModel.Procent).GreaterThanOrEqualTo(0);
        }
    }
}
