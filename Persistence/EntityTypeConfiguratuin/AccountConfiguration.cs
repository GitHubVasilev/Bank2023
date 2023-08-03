using Bank.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguratuin.Base;

namespace Persistence.EntityTypeConfiguratuin
{
    public class AccountConfiguration : IdentityEntityConfiguration<Account>
    {
        public override void AddConfiguration(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(m => m.ClientId);
            builder.Property(m => m.ClientId).HasColumnType(nameof(Guid));
            builder.HasOne(m => m.TypeAccount);
            builder.Property(m => m.TypeAccountId).HasColumnType(nameof(Guid));
            builder.Property(m => m.CountMonetaryUnit).HasColumnType(nameof(Int32));
            builder.Property(m => m.Name).HasMaxLength(64).IsRequired();
            builder.Property(m => m.Procent).HasColumnType(nameof(Int32));
            builder.Property(m => m.CountMonetaryUnit).HasColumnType(nameof(Decimal));
            builder.Property(m => m.DateOpen)
                .HasConversion(m => m, m => DateTime.SpecifyKind(m, DateTimeKind.Utc))
                .IsRequired();
            builder.Property(m => m.IsLock);
            builder.Property(m => m.IsClose);
        }

        public override string TableName()
        {
            return "Accounts";
        }
    }
}
