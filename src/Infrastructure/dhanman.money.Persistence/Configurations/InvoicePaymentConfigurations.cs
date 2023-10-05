using dhanman.money.Domain.Entities.InvoicePayments;
using dhanman.money.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dhanman.money.Persistence.Configurations;

internal class InvoicePaymentConfigurations : IEntityTypeConfiguration<InvoicePayment>
{
    #region Methods
    public void Configure(EntityTypeBuilder<InvoicePayment> builder)
    {

        builder.ToTable(TableNames.InvoicePayments);
        builder.HasKey(invoicePayment => invoicePayment.Id);

        builder.Property(invoicePayment => invoicePayment.Amount)
             .HasColumnName("amount").HasColumnType("decimal")
             .IsRequired();

        builder.Property(invoicePayment => invoicePayment.InvoiceHeaderId).HasColumnName("invoice_header_id").IsRequired();

        builder.Property(invoicePayment => invoicePayment.TransactionId).HasColumnName("transaction_id").IsRequired();

        builder.Property(invoicePayment => invoicePayment.COAId).HasColumnName("coa_id").IsRequired();

        builder.Property(invoicePayment => invoicePayment.CreatedOnUtc).HasColumnType("timestamp").IsRequired();

        builder.Property(invoicePayment => invoicePayment.ModifiedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoicePayment => invoicePayment.DeletedOnUtc).HasColumnType("timestamp").IsRequired(false);

        builder.Property(invoicePayment => invoicePayment.IsDeleted).HasDefaultValue(false).IsRequired();

        builder.HasQueryFilter(invoicePayment => !invoicePayment.IsDeleted);
    }
    #endregion

}
