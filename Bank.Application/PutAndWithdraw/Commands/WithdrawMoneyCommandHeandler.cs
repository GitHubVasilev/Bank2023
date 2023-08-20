using Bank.Application.Common.Exceptions;
using Bank.Application.Common;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Bank.Application.Interfaces;
using Bank.Application.Common.Services.ServiceModels;
using Bank.Application.PutAndWithdraw.ViewModels;
using Bank.Application.Common.AppConfig;

namespace Bank.Application.PutAndWithdraw.Commands
{
    public record WithdrawMoneyCommand(PutAndWithdrawViewModel DataWithdraw) : IRequest<WrapperResult>;

    public class WithdrawMoneyCommandHeandler : IRequestHandler<WithdrawMoneyCommand, WrapperResult>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;
        private readonly IApplicationDbContext _context;

        public WithdrawMoneyCommandHeandler(IPutAndWithdrawService putAndWithdrawService, IApplicationDbContext dbContext)
        {
            _putAndWithdrawService = putAndWithdrawService;
            _context = dbContext;
        }

        public async Task<WrapperResult> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.DataWithdraw.AccountId, cancellationToken);
            if (model == null)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.AccountNotFound, new List<Exception>() { new NotFoundException(nameof(Account), request.DataWithdraw.AccountId) });
            }
            try
            {
                await _putAndWithdrawService.WithdrawAsync
                    (
                        PutAndWithdrawServiceModel.Build(model.TypeAccount.Name, model.CountMonetaryUnit, model.Procent),
                        request.DataWithdraw.Sum, cancellationToken
                    );
            }
            catch (Exception ex)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.InnerException, new List<Exception> { ex });
            }

            _context.Accounts.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return WrapperResult.Build(0);
        }
    }
}
