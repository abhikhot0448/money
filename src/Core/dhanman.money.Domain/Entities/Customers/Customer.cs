using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace Dhanman.Money.Domain.Entities.Customers;

public class Customer : Entity, IAuditableEntity, ISoftDeletableEntity
{
    #region Properties
    public string FirstName { get;  set; }

    public Guid ClientId { get;  set; }

    public string LastName { get;  set; }

    public string PhoneNumber { get;  set; }

    public string Email { get;  set; }

    public string City { get;  set; }

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    public DateTime? DeletedOnUtc { get; }

    public bool IsDeleted { get; }

    public Guid CreatedBy { get; protected set; }

    public Guid? ModifiedBy { get; protected set; }
    #endregion

    #region Constructors
    public Customer() { }

    public Customer(Guid id, Guid clientId, string firstName, string lastName, string email, string phoneNumber, string city, Guid createdBy)
    {
        Id = id;
        ClientId = clientId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        City = city;
        CreatedBy = createdBy;
        CreatedOnUtc = DateTime.UtcNow;
    }
   
    #endregion

}