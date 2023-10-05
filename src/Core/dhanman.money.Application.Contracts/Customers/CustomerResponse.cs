namespace dhanman.money.Application.Contracts.Customers;

public sealed class CustomerResponse
{
    #region Properties

    public Guid Id { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public string PhoneNumber { get; }

    public string City { get; }

    public DateTime CreatedOnUtc { get; }
    #endregion

    #region Constructors
    public CustomerResponse(
       Guid id,
       string firstName,
       string lastName,
       string email,
       string phoneNumber,
       string city,
       DateTime createdOnUtc)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        City = city;
        CreatedOnUtc = createdOnUtc;
    }
    #endregion

}