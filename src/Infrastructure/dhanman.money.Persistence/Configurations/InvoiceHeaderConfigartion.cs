using dhanman.money.Domain.Entities.InvoiceHeaders;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

public class InvoiceHeaderConfigartion : IEntityTypeConfiguration<InvoiceHeader>
{
    #region Methods
    public void Configure(EntityTypeBuilder<InvoiceHeader> builder)
    {
        builder.ToTable(TableNames.InvoiceHeaders);
        builder.HasKey(invoiceHeader => invoiceHeader.Id);


        builder.Property(invoiceHeader => invoiceHeader.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(invoiceHeader => invoiceHeader.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoiceHeader => invoiceHeader.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoiceHeader => invoiceHeader.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(invoiceHeader => !invoiceHeader.IsDeleted);
    }
    #endregion

}
