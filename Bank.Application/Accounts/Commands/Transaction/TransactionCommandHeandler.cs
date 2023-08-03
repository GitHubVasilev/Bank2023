using Bank.Application.Interfaces.Accounts;
using MediatR;

namespace Bank.Application.Accounts.Commands.Transaction
{
    public record TrancactionCommand(Guid AccountFrom, Guid AccountTo, decimal Sum) : IRequest;

    public class TransactionCommandHeandler : IRequestHandler<TrancactionCommand>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;

        public TransactionCommandHeandler(IPutAndWithdrawService putAndWithdrawService)
        {
            _putAndWithdrawService = putAndWithdrawService;
        }

        public async Task Handle(TrancactionCommand request, CancellationToken cancellationToken)
        {
            await _putAndWithdrawService.WithdrawAsync(request.AccountFrom, request.Sum, cancellationToken);
            await _putAndWithdrawService.PutAsync(request.AccountFrom, request.Sum, cancellationToken);
        }
    }
}
