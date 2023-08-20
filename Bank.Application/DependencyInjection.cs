using Bank.Application.Common.Services;
using Bank.Application.Common.Services.Managers;
using Bank.Application.Customers.Behaviors;
using Bank.Application.Customers.Factories;
using Bank.Application.Customers.ViewModels;
using Bank.Application.Interfaces.Accounts;
using Bank.Application.Interfaces.Customers;
using Bank.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddMediatR(m => m.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<ICustomerFactoryFromUser<Customer, CustomerGetViewModel>, CustomerFromConsultantFactory>();
            services.AddScoped<ICustomerFactoryFromUser<Customer, CustomerGetViewModel>, CustomerFromManagerFactory>();
            services.AddScoped<ICustomerFactory<Customer, CustomerGetViewModel>, CustomerFactory>();

            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidatorBehavior<,>));

            services.AddSingleton<IPutAndWithdrawService, PutAndWithdrawService>(
                m => 
                {
                    PutAndWithdrawService service = new();
                    service.AddManager(new DepositePutAndWithdrawManager());
                    service.AddManager(new NoDepositePutAndWithdrawManager());
                    return service;
                });
            return services;
        }
    }
}
