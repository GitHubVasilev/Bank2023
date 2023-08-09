using Bank.Application.Common.Services.ServiceModels;

namespace Bank.Application.Interfaces.Accounts
{
    public interface IPutAndWithdrawService
    {
        public void AddManager(IPutAndWithdrawManager manager);

        public Task<PutAndWithdrawServiceModel> PutAsync(PutAndWithdrawServiceModel serviceModel, decimal sum, CancellationToken cancellationToken);
        public Task<PutAndWithdrawServiceModel> WithdrawAsync(PutAndWithdrawServiceModel serviceModel, decimal sum, CancellationToken cancellationToken);
    }
}
