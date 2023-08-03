using Bank.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlite(connectionString));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            return services;
        }
    }
}
