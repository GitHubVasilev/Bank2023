using Bank.Application.Accounts.ViewModels;
using Bank.Application.Interfaces.Accounts;
using MediatR;

namespace Bank.Application.Accounts.Commands.CreateAccount
{
    public record CreateDepositeAccountCommand(DepositeAccountPostViewModel viewModel) : IRequest;

    public class CreateDepositeAccountCommandHeandler : IRequestHandler<CreateDepositeAccountCommand>
    {
        IAccountHeandler<DepositeAccountPostViewModel> _context;

        public CreateDepositeAccountCommandHeandler(IAccountHeandler<DepositeAccountPostViewModel> service)
        {
            _context = service;
        }

        public async Task Handle(CreateDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            await _context.CreateAccountAsync(request.viewModel, cancellationToken);
        }
    }
}
