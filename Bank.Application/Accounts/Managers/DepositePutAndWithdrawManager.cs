using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using Bank.Domain.Base;

namespace Bank.Application.Accounts.Managers
{
    internal class DepositePutAndWithdrawManager : IPutAndWithdrawManager
    {
        public IPutAndWithdrawManager? NextManager { get; set; }

        public Account Put(Account model, decimal sum)
        {
            if (model.TypeAccount.Name == AppData.DepositeAccountTypeName) 
            {
                sum *= 1 + model.Procent / 100;
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
            if (model.TypeAccount.Name == AppData.DepositeAccountTypeName)
            {
                if (model.CountMonetaryUnit > 0)
                {
                    sum *= 1 + model.Procent / 100;
                }
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
