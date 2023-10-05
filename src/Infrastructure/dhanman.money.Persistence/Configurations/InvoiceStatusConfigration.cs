using dhanman.money.Domain.Entities.InvoiceStatuses;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

public class InvoiceStatusConfigration : IEntityTypeConfiguration<InvoiceStatus>
{
    #region Methods
    public void Configure(EntityTypeBuilder<InvoiceStatus> builder)
    {
        builder.ToTable(TableNames.InvoiceStatuses);
        builder.HasKey(invoiceStatus => invoiceStatus.Id);

        builder.Property(invoiceStatus => invoiceStatus.Name)
            .HasColumnName("name")
             .HasMaxLength(Name.MaxLength)
             .IsRequired();




        builder.Property(invoiceStatus => invoiceStatus.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(invoiceStatus => invoiceStatus.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoiceStatus => invoiceStatus.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoiceStatus => invoiceStatus.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(invoiceStatus => !invoiceStatus.IsDeleted);
    }
    #endregion

}
