using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.InvoiceDetails;

public class InvoiceDetail : Entity, IAuditableEntity, ISoftDeletableEntity
{
    #region Properties
    public Guid InvoiceHeaderId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }
    public Guid CreatedBy { get; protected set; }
    public Guid? ModifiedBy { get; protected set; }
    public DateTime CreatedOnUtc { get; }
    public DateTime? ModifiedOnUtc { get; }
    public DateTime? DeletedOnUtc { get; }
    public bool IsDeleted { get; }
    #endregion

    #region Constructor
    public InvoiceDetail() { }
    public InvoiceDetail(Guid id, Guid invoiceHeaderId, string name, string description, decimal price, int quantity, decimal amount)
    {
        Id = id;
        InvoiceHeaderId = invoiceHeaderId;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;
        CreatedOnUtc = DateTime.UtcNow;
    }

    #endregion

}
