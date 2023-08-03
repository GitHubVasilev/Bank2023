using Bank.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfiguratuin.Base
{
    public abstract class AuditableConfiguration<T> : IEntityTypeConfiguration<T> where T : Auditable
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName());
            builder.HasKey(m => m.UID);
            builder.Property(m => m.UID).HasColumnType(nameof(Guid)).IsRequired();

            builder.Property(m => m.UpdatedAt)
                .HasConversion(m => m, m => DateTime.SpecifyKind(m, DateTimeKind.Utc));
            builder.Property(m => m.CreatedAt)
                .HasConversion(m => m, m => DateTime.SpecifyKind(m, DateTimeKind.Utc));
            builder.Property(m => m.CreatedBy)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(m => m.UpdatedBy)
                .HasMaxLength(256);
        }

        public abstract void AddConfiguration(EntityTypeBuilder<T> builder);

        public abstract string TableName();
    }
}
