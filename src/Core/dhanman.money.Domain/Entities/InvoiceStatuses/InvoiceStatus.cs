using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.InvoiceStatuses;

public class InvoiceStatus : Entity, IAuditableEntity, ISoftDeletableEntity
{

    #region Properties
    public string Name { get; private set; }
    public Guid ClientId { get; private set; }

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool IsDeleted { get; }

    public Guid CreatedBy { get; protected set; }

    public Guid? ModifiedBy { get; protected set; }
    #endregion

    #region Constructors
    public InvoiceStatus() { }
    public InvoiceStatus(Guid id, string name, Guid createdBy, Guid clientId)
    {
        Id = id;
        Name = name;
        CreatedBy = createdBy;
        ClientId = clientId;
        CreatedOnUtc = DateTime.UtcNow;
    }
    #endregion

}
