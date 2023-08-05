using Bank.Application.Accounts.Services.ServiceModels;
using Bank.Application.Common.Exceptions;
using Bank.Application.Common;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Bank.Application.Interfaces;

namespace Bank.Application.Accounts.Commands.PutAndWithdraw
{
    public record WithdrawDepositeAccountCommand(Guid UID, decimal Sum) : IRequest<WrapperResult>;

    public class WithdrawDepositeAccountCommandHeandler : IRequestHandler<WithdrawDepositeAccountCommand, WrapperResult>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;
        private readonly IApplicationDbContext _context;

        public WithdrawDepositeAccountCommandHeandler(IPutAndWithdrawService putAndWithdrawService, IApplicationDbContext dbContext)
        {
            _putAndWithdrawService = putAndWithdrawService;
            _context = dbContext;
        }

        public async Task<WrapperResult> Handle(WithdrawDepositeAccountCommand request, CancellationToken cancellationToken)
        {
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.UID, cancellationToken);
            if (model == null)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.AccountNotFound, new NotFoundException(nameof(Account), request.UID));
            }
            try
            {
                await _putAndWithdrawService.WithdrawAsync
                    (
                        PutAndWithdrawServiceModel.Build(model.TypeAccount.Name, model.CountMonetaryUnit, model.Procent),
                        request.Sum, cancellationToken
                    );
            }
            catch (Exception ex)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.InnerException, ex);
            }

            _context.Accounts.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return WrapperResult.Build(0);
        }
    }
}
