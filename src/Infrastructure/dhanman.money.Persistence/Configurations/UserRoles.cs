using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal sealed class UserRoles : IEntityTypeConfiguration<Domain.Authorization.UserPaidModules>
{
    #region Methods
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Domain.Authorization.UserPaidModules> builder)
    {
        builder.ToTable(TableNames.UserRoles);

        builder.HasKey(m => m.UserId);

        builder.Property(m => m.PaidModules).IsRequired();
    }
    #endregion

}