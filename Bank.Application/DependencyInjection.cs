using Bank.Application.Accounts.Managers;
using Bank.Application.Accounts.Services;
using Bank.Application.Accounts.ViewModels;
using Bank.Application.Accounts.ViewModels.DepositeAccounts;
using Bank.Application.Accounts.ViewModels.NoDepositeAccounts;
using Bank.Application.Customers.Factories;
using Bank.Application.Customers.Validations;
using Bank.Application.Customers.Validations.RulesValidation;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces;
using Bank.Application.Interfaces.Accounts;
using Bank.Application.Interfaces.Customers;
using Bank.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IAccountHeandler<DepositeAccountPostViewModel>, AccountService<DepositeAccountPostViewModel>>();
            services.AddScoped<IAccountHeandler<NoDepositeAccountPostViewModel>, AccountService<NoDepositeAccountPostViewModel>>();
            services.AddScoped<IValidationRules<CustomerPutUpdateViewModel>, FirstNameCustomerValidationRules>();
            services.AddScoped<IValidationRules<CustomerPutUpdateViewModel>, LastNameCustomerValidationRules>();
            services.AddScoped<IValidationRules<CustomerPutUpdateViewModel>, PatronymicCustomerValidationRules>();
            services.AddScoped<IValidationRules<CustomerPutUpdateViewModel>, TelephoneCustomerValidationRules>();
            services.AddScoped<IValidationRules<CustomerPutUpdateViewModel>, PassportCustomerValidationRules>();
            services.AddScoped<IValidator<CustomerPutUpdateViewModel>, ValidatorCustomer>();
            services.AddScoped<ICustomerFactoryFromUser<Customer, CustomerGetViewModel>, CustomerFromConsultantFactory>();
            services.AddScoped<ICustomerFactoryFromUser<Customer, CustomerGetViewModel>, CustomerFromManagerFactory>();
            services.AddScoped<ICustomerFactory<Customer, CustomerGetViewModel>, CustomerFactory>();
            services.AddSingleton<IPutAndWithdrawService, PutAndWithdrawService>(
                m => 
                {
                    PutAndWithdrawService service = new(m.GetService<IApplicationDbContext>());
                    service.AddManager(new DepositePutAndWithdrawManager());
                    service.AddManager(new NoDepositePutAndWithdrawManager());
                    return service;
                });
            return services;
        }
    }
}
