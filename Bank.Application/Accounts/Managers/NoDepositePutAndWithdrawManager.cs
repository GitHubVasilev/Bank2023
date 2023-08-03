using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using Bank.Domain.Base;

namespace Bank.Application.Accounts.Managers
{
    internal class NoDepositePutAndWithdrawManager : IPutAndWithdrawManager
    {
        public IPutAndWithdrawManager? NextManager { get; set; }
        public Account Put(Account model, decimal sum)
        {
            if (model.TypeAccount.Name == AppData.NoDepositeAccountTypeName)
            {
                model.CountMonetaryUnit += sum;

            }
            else if (NextManager is not null) 
            {
                model = NextManager.Put(model, sum);
            }
            return model;
        }

        public Account Withdraw(Account model, decimal sum)
        {
            if (model.TypeAccount.Name == AppData.NoDepositeAccountTypeName)
            {
                model.CountMonetaryUnit -= sum;

            }
            else if (NextManager is not null)
            {
                model = NextManager.Withdraw(model, sum);
            }
            return model;
        }
    }
}
