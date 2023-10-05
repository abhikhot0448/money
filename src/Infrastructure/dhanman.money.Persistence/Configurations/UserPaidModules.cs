using Dhanman.Money.Domain.Authorization;
using Dhanman.Money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dhanman.Money.Persistence.Configurations;

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
