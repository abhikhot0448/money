using dhanman.money.Domain.Entities.InvoiceDetails;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal sealed class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
{
    public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
    {
        #region Methods
        builder.ToTable(TableNames.InvoiceDetails);
        builder.HasKey(invoiceDetail => invoiceDetail.Id);


        builder.Property(invoiceDetail => invoiceDetail.InvoiceHeaderId)
           .HasColumnName("invoice_header_id")
            .IsRequired();

        builder.Property(invoiceDetail => invoiceDetail.Name)
        .HasColumnName("name")
                .IsRequired();

        builder.Property(invoiceDetail => invoiceDetail.Description)
        .HasColumnName("description")
                .IsRequired();

        builder.Property(invoiceDetail => invoiceDetail.Price)
        .HasColumnName("price")
                .IsRequired();

        builder.Property(invoiceDetail => invoiceDetail.Quantity)
        .HasColumnName("quantity")
                .IsRequired();

        builder.Property(invoiceDetail => invoiceDetail.Amount)
        .HasColumnName("amount")
                .IsRequired();


        builder.Property(invoiceDetail => invoiceDetail.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(invoiceDetail => invoiceDetail.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoiceDetail => invoiceDetail.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoiceDetail => invoiceDetail.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(invoiceDetail => !invoiceDetail.IsDeleted);
        #endregion

    }
}
