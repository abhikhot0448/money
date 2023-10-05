using dhanman.money.Domain.Authorization;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal sealed class UserPaidModules : IEntityTypeConfiguration<UserRole>
{
    #region Methods
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable(TableNames.UserPaidModules);

        builder.HasKey(m => new { m.UserId, m.RoleName });
    }
    #endregion

}
