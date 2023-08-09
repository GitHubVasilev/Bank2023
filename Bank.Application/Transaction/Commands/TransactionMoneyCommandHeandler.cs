using Bank.Application.Common.Exceptions;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Bank.Application.Common.Services.ServiceModels;
using Bank.Application.Transaction.ViewModels;

namespace Bank.Application.Transaction.Commands
{
    public record TrancactionMoneyCommand(TransactionViewModel DataTransaction) : IRequest<WrapperResult>;

    public class TransactionMoneyCommandHeandler : IRequestHandler<TrancactionMoneyCommand, WrapperResult>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;
        private readonly IApplicationDbContext _context;

        public TransactionMoneyCommandHeandler(IPutAndWithdrawService putAndWithdrawService, IApplicationDbContext dbContext)
        {
            _putAndWithdrawService = putAndWithdrawService;
            _context = dbContext;
        }

        public async Task<WrapperResult> Handle(TrancactionMoneyCommand request, CancellationToken cancellationToken)
        {
            Account? modelFrom = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.DataTransaction.AccountFrom, cancellationToken);
            if (modelFrom == null)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.AccountNotFound, new NotFoundException(nameof(Account), request.DataTransaction.AccountFrom));
            }
            Account? modelTo = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.DataTransaction.AccountFrom, cancellationToken);
            if (modelTo == null)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.AccountNotFound, new NotFoundException(nameof(Account), request.DataTransaction.AccountTo));
            }
            PutAndWithdrawServiceModel serviceModelFrom = await _putAndWithdrawService.WithdrawAsync
                (
                    PutAndWithdrawServiceModel.Build(modelFrom.TypeAccount.Name, modelFrom.CountMonetaryUnit, modelFrom.Procent)
                    , request.DataTransaction.Sum
                    , cancellationToken
                );
            modelFrom.CountMonetaryUnit = serviceModelFrom.StartSum;
            PutAndWithdrawServiceModel serviceModelTo = await _putAndWithdrawService.WithdrawAsync
                (
                    PutAndWithdrawServiceModel.Build(modelTo.TypeAccount.Name, modelTo.CountMonetaryUnit, modelTo.Procent)
                    , request.DataTransaction.Sum
                    , cancellationToken
                );
            modelTo.CountMonetaryUnit = serviceModelTo.StartSum;
            _context.Accounts.Update(modelFrom);
            _context.Accounts.Update(modelTo);
            await _context.SaveChangesAsync(cancellationToken);

            return WrapperResult.Build(0);
        }
    }
}
