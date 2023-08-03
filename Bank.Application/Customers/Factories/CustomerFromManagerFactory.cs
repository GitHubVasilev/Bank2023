using Bank.Application.Common.Exceptions;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces.Customers;
using Bank.Domain;
using Bank.Domain.Base;

namespace Bank.Application.Customers.Factories
{
    internal class CustomerFromManagerFactory : ICustomerFactoryFromUser<Customer, CustomerGetViewModel>
    {
        public void Create(Customer model, ref CustomerGetViewModel viewModel, string userName)
        {
            if (model != null)
            {
                if (userName == AppData.ManagerUser)
                    viewModel = new CustomerGetViewModel()
                    {
                        UID = model.UID,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Patronymic = model.Patronymic,
                        Telephone = model.Telephone,
                        Passport = string.IsNullOrEmpty(model.Passport) ? string.Empty : "******************",
                        CreatedAt = model.CreatedAt,
                        CreatedBy = model.CreatedBy,
                        UpdatedAt = model.UpdatedAt,
                        UpdatedBy = model.UpdatedBy
                    };
            }
            else 
            {
                throw new ArgumentIsNull(nameof(model));
            }
        }
    }
}
