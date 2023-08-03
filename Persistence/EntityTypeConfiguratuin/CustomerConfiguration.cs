using Bank.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguratuin.Base;

namespace Persistence.EntityTypeConfiguratuin
{
    internal class CustomerConfiguration : AuditableConfiguration<Customer>
    {
        public override void AddConfiguration(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(m => m.FirstName).HasMaxLength(64).IsRequired();
            builder.Property(m => m.LastName).HasMaxLength(64).IsRequired();
            builder.Property(m => m.Patronymic).HasMaxLength(64);
            builder.Property(m => m.Telephone).HasMaxLength(32);
            builder.Property(m => m.Passport).HasMaxLength(32);
        }

        public override string TableName()
        {
            return "Customers";
        }
    }
}
