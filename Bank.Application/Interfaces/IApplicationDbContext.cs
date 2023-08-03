using Bank.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Account> Accounts { get; }
        DbSet<Customer> Customers { get; }
        DbSet<Customer> TypesAccount { get; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
