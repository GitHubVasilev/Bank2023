using Bank.Application.Accounts.Services.ServiceModels;

namespace Bank.Application.Interfaces.Accounts
{
    public interface IPutAndWithdrawService
    {
        public void AddManager(IPutAndWithdrawManager manager);

        public Task<PutAndWithdrawServiceModel> PutAsync(PutAndWithdrawServiceModel serviceModel, CancellationToken cancellationToken);
        public Task<PutAndWithdrawServiceModel> WithdrawAsync(PutAndWithdrawServiceModel serviceModel, CancellationToken cancellationToken);
    }
}
