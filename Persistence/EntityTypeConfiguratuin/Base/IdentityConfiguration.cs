using Bank.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfiguratuin.Base
{
    public abstract class IdentityEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Identity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName());
            builder.HasKey(m => m.UID);
            builder.Property(m => m.UID).HasColumnType(nameof(Guid)).IsRequired();
        }

        public abstract void AddConfiguration(EntityTypeBuilder<T> builder);
        public abstract string TableName();
    }
}
