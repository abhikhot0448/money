using B2aTech.CrossCuttingConcern.Core.Abstractions;
using B2aTech.CrossCuttingConcern.Core.Primitives;
using Dhanman.Money.Domain.Entities.Customers;
using Dhanman.Money.Domain.Entities.Users.Services;
using Dhanman.Money.Domain.Utility;

namespace Dhanman.Money.Domain.Entities.Users;

public class User : Entity, IAuditableEntity, ISoftDeletableEntity
{
    #region Properties
    private string _passwordHash;

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
    public User(Guid id, FirstName firstName, LastName lastName, Email email, string passwordHash)
        : this()
    {
        Ensure.NotEmpty(id, "The identifier is required.", nameof(id));
        Ensure.NotEmpty(firstName, "The first name is required.", nameof(firstName));
        Ensure.NotEmpty(lastName, "The last name is required.", nameof(lastName));
        Ensure.NotEmpty(email, "The email is required.", nameof(email));
        Ensure.NotEmpty(passwordHash, "The password hash is required", nameof(passwordHash));

        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _passwordHash = passwordHash;
    }

    protected User()
    {
        FirstName = FirstName.Empty;
        LastName = LastName.Empty;
        Email = Email.Empty;
        _passwordHash = string.Empty;
    }
    #endregion

    #region Methodes
    public bool VerifyPasswordHash(string password, IPasswordHashChecker passwordHashChecker)
        => !string.IsNullOrWhiteSpace(password) && passwordHashChecker.HashesMatch(_passwordHash, password);
    #endregion
}