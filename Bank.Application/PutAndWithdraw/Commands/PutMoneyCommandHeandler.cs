using Bank.Application.Common;
using Bank.Application.Common.AppConfig;
using Bank.Application.Common.Exceptions;
using Bank.Application.Common.Services.ServiceModels;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Accounts;
using Bank.Application.PutAndWithdraw.ViewModels;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.PutAndWithdraw.Commands
{
    public record PutMoneyCommand(PutAndWithdrawViewModel DataPut) : IRequest<WrapperResult>;

    public class PutMoneyCommandHeandler : IRequestHandler<PutMoneyCommand, WrapperResult>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;
        private readonly IApplicationDbContext _context;

        public PutMoneyCommandHeandler(IPutAndWithdrawService putAndWithdrawService, IApplicationDbContext dbContext)
        {
            _putAndWithdrawService = putAndWithdrawService;
            _context = dbContext;
        }

        public async Task<WrapperResult> Handle(PutMoneyCommand request, CancellationToken cancellationToken)
        {
            WrapperResult result = WrapperResult.Build<int>();
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.DataPut.AccountId, cancellationToken);
            if (model == null)
            {
                result.ExceptionObjects.Add(new NotFoundException(nameof(Account), request.DataPut.AccountId));
                result.Message = ReferencesTextResponse.AccountNotFound;
                return result;
            }
            try
            {
                await _putAndWithdrawService.PutAsync
                    (
                        PutAndWithdrawServiceModel.Build(model.TypeAccount.Name, model.CountMonetaryUnit, model.Procent),
                        request.DataPut.Sum, cancellationToken
                    );
            }
            catch (Exception ex)
            {
                result.Message = ReferencesTextResponse.InnerException;
                result.ExceptionObjects.Add(ex);
                return result;
            }

            _context.Accounts.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
