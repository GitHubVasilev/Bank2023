using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces.Customers;
using Bank.Domain;


namespace Bank.Application.Customers.Factories
{
    public class CustomerFactory : ICustomerFactory<Customer, CustomerGetViewModel>
    {
        private readonly IEnumerable<ICustomerFactoryFromUser<Customer, CustomerGetViewModel>> _factories;

        public CustomerFactory(IEnumerable<ICustomerFactoryFromUser<Customer, CustomerGetViewModel>> factories)
        {
            _factories = factories;
        }

        public CustomerGetViewModel GetCustomerFromUser(Customer model, string userName)
        {
            CustomerGetViewModel? result = null;

            foreach (var factory in _factories) 
            {
                factory.Create(model, ref result, userName);
            }
            if (result == null) 
            {
                return new CustomerGetViewModel()
                {
                    UID = model.UID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Patronymic = model.Patronymic,
                    Telephone = model.Telephone,
                    Passport = model.Passport,
                    CreatedAt = model.CreatedAt,
                    CreatedBy = model.CreatedBy,
                    UpdatedAt = model.UpdatedAt,
                    UpdatedBy = model.UpdatedBy
                };
            }
            return result;
        }
    }
}
