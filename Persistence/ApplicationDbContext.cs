using Bank.Application.Interfaces;
using Bank.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfiguratuin;

namespace Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Customer> TypesAccount { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TypeAccountConfiguraton());
        }
    }
}
