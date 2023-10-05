using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Domain.Entities.Customers;

public class Customer_old : Entity, IAuditableEntity, ISoftDeletableEntity
{
    #region Properties

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool IsDeleted { get; }

    public Guid CreatedBy { get; protected set; }

    public Guid? ModifiedBy { get; protected set; }
    #endregion

    #region Constructors

    public Customer_old() { }
    public Customer_old(Guid id, FirstName firstName, LastName lastName, Email email, Guid createdBy)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        CreatedBy = createdBy;
        CreatedOnUtc = DateTime.UtcNow;
    }
   
    #endregion

}
