using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.InvoicePayments
{
    public class InvoicePayment : Entity, IAuditableEntity, ISoftDeletableEntity
    {
        #region Properties
        public Guid ClientId { get; private set; }
        public decimal Amount { get; private set; }
        public Guid InvoiceHeaderId { get; private set; }
        public Guid TransactionId { get; private set; }
        public Guid COAId { get; private set; }
        public Guid CreatedBy { get; protected set; }
        public Guid? ModifiedBy { get; protected set; }
        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; }
        public DateTime? DeletedOnUtc { get; }
        public bool IsDeleted { get; }
        #endregion

        #region Constructor
        public InvoicePayment(
            Guid id, Guid clientId, decimal amount, Guid invoiceHeaderId, Guid transactionId,
            Guid cOAId, Guid createdBy)
        {
            Id = id;
            ClientId = clientId;
            Amount = amount;
            InvoiceHeaderId = invoiceHeaderId;
            TransactionId = transactionId;
            COAId = cOAId;
            CreatedBy = createdBy;
            CreatedOnUtc = DateTime.UtcNow;
        }

        public InvoicePayment()
        {

        }
        #endregion

    }
}
