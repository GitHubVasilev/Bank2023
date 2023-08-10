using Bank.Application.Common.Exceptions;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Bank.Application.Common.Services.ServiceModels;
using Bank.Application.Transaction.ViewModels;
using System.Diagnostics.CodeAnalysis;

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
            WrapperResult result = WrapperResult.Build<int>();
            Account? modelFrom = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.DataTransaction.AccountFrom, cancellationToken);
            if (modelFrom == null)
            {
                result.Message = ReferencesTextResponse.AccountNotFound;
                result.ExceptionObjects.Add(new NotFoundException(nameof(Account), request.DataTransaction.AccountFrom));
                return result;
            }
            Account? modelTo = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.DataTransaction.AccountFrom, cancellationToken);
            if (modelTo == null)
            {
                result.Message = ReferencesTextResponse.AccountNotFound;
                result.ExceptionObjects.Add(new NotFoundException(nameof(Account), request.DataTransaction.AccountTo));
                return result;
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

            return result;
        }
    }
}
