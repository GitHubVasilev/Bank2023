using Bank.Application.Common.Exceptions;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Accounts.Services
{
    public class PutAndWithdrawService : IPutAndWithdrawService
    {
        private IPutAndWithdrawManager? _startManagment;
        private IPutAndWithdrawManager? _currentManegment;
        private readonly IApplicationDbContext _context;

        public PutAndWithdrawService(IApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddManager(IPutAndWithdrawManager manager)
        {
            if (_startManagment is null) 
            {
                _startManagment = manager;
                _currentManegment = manager;
            }
            _currentManegment.NextManager = manager;
            _currentManegment = _currentManegment.NextManager;
        }

        public async Task PutAsync(Guid accountId, decimal sum, CancellationToken cancellationToken)
        {
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == accountId, cancellationToken)
                ?? throw new NotFoundException(nameof(Account), accountId);
            model = _startManagment?.Put(model, sum);

            _context.Accounts.Update(model);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task WithdrawAsync(Guid accountId, decimal sum, CancellationToken cancellationToken)
        {
            Account? model = await _context.Accounts.FirstOrDefaultAsync(m => m.UID == accountId, cancellationToken)
                ?? throw new NotFoundException(nameof(Account), accountId);

            model = _startManagment?.Withdraw(model, sum);

            _context.Accounts.Update(model);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
