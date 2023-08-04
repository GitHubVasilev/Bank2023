using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Bank.Application.Common;
using Bank.Application.Interfaces.Accounts;
using MediatR;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
    public record CreateDepositeAccountCommand(DepositeAccountPostViewModel viewModel) : IRequest<WrapperResult>;

    public class CreateDepositeAccountCommandHeandler : IRequestHandler<CreateDepositeAccountCommand, WrapperResult>
    {
        IAccountHeandler<DepositeAccountPostViewModel> _context;

        public CreateDepositeAccountCommandHeandler(IAccountHeandler<DepositeAccountPostViewModel> service)
        {
            _context = service;
        }

        public async Task<WrapperResult> Handle(CreateDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            await _context.CreateAccountAsync(request.viewModel, cancellationToken);
        }
    }
}
