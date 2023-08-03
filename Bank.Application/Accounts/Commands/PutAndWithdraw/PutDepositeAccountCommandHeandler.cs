using Bank.Application.Interfaces.Accounts;
using MediatR;

namespace Bank.Application.Accounts.Commands.PutAndWithdraw
{
    public record PutDepositeAccountCommand(Guid UID, decimal Sum) : IRequest;

    public class PutDepositeAccountCommandHeandler : IRequestHandler<PutDepositeAccountCommand>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;

        public PutDepositeAccountCommandHeandler(IPutAndWithdrawService putAndWithdrawService)
        {
            _putAndWithdrawService = putAndWithdrawService;
        }

        public async Task Handle(PutDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            await _putAndWithdrawService.PutAsync(request.UID, request.Sum, cancellationToken);
        }
    }
}
