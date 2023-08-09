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

        public DbSet<TypeAccount> TypesAccount { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TypeAccountConfiguraton());

            modelBuilder.Entity<Account>().Property(m => m.UID).HasConversion(g => g.ToString(), s => new Guid(s));
            modelBuilder.Entity<Customer>().Property(m => m.UID).HasConversion(g => g.ToString(), s => new Guid(s));
            modelBuilder.Entity<TypeAccount>().Property(m => m.UID).HasConversion(g => g.ToString(), s => new Guid(s));

        }
    }
}
