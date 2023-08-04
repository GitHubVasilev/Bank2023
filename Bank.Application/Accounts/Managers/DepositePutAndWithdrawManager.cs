using Bank.Application.Accounts.Services.ServiceModels;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain;
using Bank.Domain.Base;

namespace Bank.Application.Accounts.Managers
{
    internal class DepositePutAndWithdrawManager : IPutAndWithdrawManager
    {
        public IPutAndWithdrawManager? NextManager { get; set; }

        public PutAndWithdrawServiceModel Put(PutAndWithdrawServiceModel serviceModel, decimal sum)
        {
            if (serviceModel.TypeAccount == AppData.DepositeAccountTypeName) 
            {
                sum *= 1 + serviceModel.Procent / 100;
                serviceModel.StartSum += sum;
            }
            else if (NextManager is not null) 
            {
                serviceModel = NextManager.Put(serviceModel, sum);
            }
            return serviceModel;
        }

        public PutAndWithdrawServiceModel Withdraw(PutAndWithdrawServiceModel serviceModel, decimal sum)
        {
            if (serviceModel.TypeAccount == AppData.DepositeAccountTypeName)
            {
                if (serviceModel.StartSum > 0)
                {
                    sum *= 1 + serviceModel.Procent / 100;
                }
                serviceModel.StartSum -= sum;
            }
            else if (NextManager is not null) 
            {
                serviceModel = NextManager.Withdraw(serviceModel, sum);
            }
            return serviceModel;
        }
    }
}
