﻿using Bank.Application.Common.Services.ServiceModels;
using Bank.Application.Interfaces.Accounts;
using Bank.Domain.Base;

namespace Bank.Application.Common.Services.Managers
{
    internal class NoDepositePutAndWithdrawManager : IPutAndWithdrawManager
    {
        public IPutAndWithdrawManager? NextManager { get; set; }
        public PutAndWithdrawServiceModel Put(PutAndWithdrawServiceModel model, decimal sum)
        {
            if (model.TypeAccount == AppData.NoDepositeAccountTypeName)
            {
                model.StartSum += sum;
            }
            else if (NextManager is not null)
            {
                model = NextManager.Put(model, sum);
            }
            return model;
        }

        public PutAndWithdrawServiceModel Withdraw(PutAndWithdrawServiceModel model, decimal sum)
        {
            if (model.TypeAccount == AppData.NoDepositeAccountTypeName)
            {
                model.StartSum -= sum;
            }
            else if (NextManager is not null)
            {
                model = NextManager.Withdraw(model, sum);
            }
            return model;
        }
    }
}
