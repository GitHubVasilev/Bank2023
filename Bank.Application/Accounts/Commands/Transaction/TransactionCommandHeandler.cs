using Bank.Application.Accounts.Services.ServiceModels;
using Bank.Application.Common.Exceptions;
using Bank.Application.Common;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Commands.Transaction
{
    public record TrancactionCommand(Guid AccountFrom, Guid AccountTo, decimal Sum) : IRequest<WrapperResult>;

    public class TransactionCommandHeandler : IRequestHandler<TrancactionCommand, WrapperResult>
    {
        private readonly IPutAndWithdrawService _putAndWithdrawService;
        private readonly IApplicationDbContext _context;

        public TransactionCommandHeandler(IPutAndWithdrawService putAndWithdrawService, IApplicationDbContext dbContext)
        {
            _putAndWithdrawService = putAndWithdrawService;
            _context = dbContext;
        }

        public async Task<WrapperResult> Handle(TrancactionCommand request, CancellationToken cancellationToken)
        {
            Account? modelFrom = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.AccountFrom, cancellationToken);
            if (modelFrom == null)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.AccountNotFound, new NotFoundException(nameof(Account), request.AccountFrom));
            }
            Account? modelTo = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.AccountFrom, cancellationToken);
            if (modelTo == null)
            {
                return WrapperResult.Build(1, ReferencesTextResponse.AccountNotFound, new NotFoundException(nameof(Account), request.AccountTo));
            }
            PutAndWithdrawServiceModel serviceModelFrom = await _putAndWithdrawService.WithdrawAsync
                (
                    PutAndWithdrawServiceModel.Build(modelFrom.TypeAccount.Name, modelFrom.CountMonetaryUnit, modelFrom.Procent)
                    , request.Sum
                    , cancellationToken
                );
            modelFrom.CountMonetaryUnit = serviceModelFrom.StartSum;
            PutAndWithdrawServiceModel serviceModelTo = await _putAndWithdrawService.WithdrawAsync
                (
                    PutAndWithdrawServiceModel.Build(modelTo.TypeAccount.Name, modelTo.CountMonetaryUnit, modelTo.Procent)
                    , request.Sum
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
