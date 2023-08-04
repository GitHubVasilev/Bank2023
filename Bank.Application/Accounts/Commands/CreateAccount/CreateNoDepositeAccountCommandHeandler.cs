using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;
using Bank.Application.Interfaces.Accounts;
using MediatR;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
    public record CreateNoDepositeAccountCommand(NoDepositeAccountPostViewModel viewModel) : IRequest;

    public class CreateNoDepositeAccountCommandHeandler : IRequestHandler<CreateNoDepositeAccountCommand>
    {
        IAccountHeandler<NoDepositeAccountPostViewModel> _context;

        public CreateNoDepositeAccountCommandHeandler(IAccountHeandler<NoDepositeAccountPostViewModel> service)
        {
            _context = service;
        }

        public async Task Handle(CreateNoDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            await _context.CreateAccountAsync(request.viewModel, cancellationToken);
        }
    }
}
