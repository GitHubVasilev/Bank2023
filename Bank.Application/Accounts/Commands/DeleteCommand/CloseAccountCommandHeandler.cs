using Bank.Application.Common;
using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Commands.DeleteCommand
{
    public record CloseAccountCommand(Guid UID): IRequest<WrapperResult>;
    public class CloseAccountCommandHeandler : IRequestHandler<CloseAccountCommand, WrapperResult>
    {
        private readonly IApplicationDbContext _context;

        public CloseAccountCommandHeandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<WrapperResult> Handle(CloseAccountCommand request, CancellationToken cancellationToken)
        {
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == request.UID, cancellationToken);

            if (model == null)
            {
                return WrapperResult.Build<int>(1, ReferencesTextResponse.AccountNotFound, new List<Exception>{ new NotFoundException(nameof(Account), request.UID) });
            }

            model.IsClose = true;
            await _context.SaveChangesAsync(cancellationToken);
            return WrapperResult.Build(0);
        }
    }
}
