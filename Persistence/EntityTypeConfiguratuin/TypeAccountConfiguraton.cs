using Bank.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.EntityTypeConfiguratuin.Base;

namespace Persistence.EntityTypeConfiguratuin
{
    internal class TypeAccountConfiguraton : IdentityEntityConfiguration<TypeAccount>
    {
        public override void AddConfiguration(EntityTypeBuilder<TypeAccount> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(128).IsRequired();
        }

        public override string TableName()
        {
            return "TypeAccounts";
        }
    }
}
