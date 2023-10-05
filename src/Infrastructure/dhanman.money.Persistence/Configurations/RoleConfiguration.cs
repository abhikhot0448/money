using dhanman.money.Domain.Authorization;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    #region Methods
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(TableNames.Roles);

        builder.HasKey(r => r.Name);

        builder.Property(r => r.Name).HasMaxLength(50).IsRequired();

        builder.Property(r => r.Description).HasMaxLength(200).IsRequired(false);

        builder.Property(r => r.Permissions).HasField("_permissions").HasColumnType("int[]").IsRequired();

        builder.Ignore(r => r.Permissions);
    }
    #endregion

}
