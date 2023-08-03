namespace Bank.Application.Interfaces.Accounts
{
    public interface IPutAndWithdrawService
    {
        public void AddManager(IPutAndWithdrawManager manager);

        public Task PutAsync(Guid accountId, decimal sum, CancellationToken cancellationToken);
        public Task WithdrawAsync(Guid accountId, decimal sum, CancellationToken cancellationToken);
    }
}
