using Bank.Application.Interfaces.Accounts;
using MediatR;

namespace Bank.Application.Accounts.Commands.PutAndWithdraw
{
    public record WithdrawDepositeAccountCommand(Guid UID, decimal Sum) : IRequest;

    public class WithdrawDepositeAccountCommandHeandler : IRequestHandler<WithdrawDepositeAccountCommand>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;

        public WithdrawDepositeAccountCommandHeandler(IPutAndWithdrawService putAndWithdrawService)
        {
            _putAndWithdrawService = putAndWithdrawService;
        }

        public async Task Handle(WithdrawDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            await _putAndWithdrawService.WithdrawAsync(request.UID, request.Sum, cancellationToken);
        }
    }
}
