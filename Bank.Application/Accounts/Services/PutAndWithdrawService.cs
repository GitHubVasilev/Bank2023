using Bank.Application.Accounts.Services.ServiceModels;
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

        public PutAndWithdrawService()
        {

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

        public async Task<PutAndWithdrawServiceModel> PutAsync(PutAndWithdrawServiceModel serviceModel, decimal sum, CancellationToken cancellationToken)
        {
            PutAndWithdrawServiceModel? resultPut = _startManagment?.Put
                (
                    serviceModel,
                    sum
                );
            return resultPut is null ? throw new ManagersNotFoundException(nameof(PutAndWithdrawService)) : resultPut;
        }

        public async Task<PutAndWithdrawServiceModel> WithdrawAsync(PutAndWithdrawServiceModel serviceModel, decimal sum, CancellationToken cancellationToken)
        {
            PutAndWithdrawServiceModel? resultPut = _startManagment?.Withdraw
                (
                    serviceModel,
                    sum
                );
            return resultPut is null ? throw new ManagersNotFoundException(nameof(PutAndWithdrawService)) : resultPut;
        }
    }
}
