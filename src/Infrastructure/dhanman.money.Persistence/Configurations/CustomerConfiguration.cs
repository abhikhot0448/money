using dhanman.money.Domain.Entities.Customers;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    #region Methods
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(TableNames.Customers);
        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.FirstName)
            .HasColumnName("first_name")
             .HasMaxLength(FirstName.MaxLength)
             .IsRequired();

        builder.Property(customer => customer.LastName)
        .HasColumnName("last_name")
                .HasMaxLength(LastName.MaxLength)
                .IsRequired();

        builder.Property(customer => customer.Email)
       .HasColumnName("email")
                .HasMaxLength(Email.MaxLength)
                .IsRequired();

        builder.Property(customer => customer.PhoneNumber)
       .HasColumnName("phone_number")
              .HasMaxLength(PhoneNumber.MaxLength)
              .IsRequired();

        builder.Property(customer => customer.City)
            .HasColumnName("city")
             .IsRequired();

        builder.Property(customer => customer.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(customer => customer.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(customer => customer.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(customer => customer.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(customer => !customer.IsDeleted);
    }
    #endregion

}
