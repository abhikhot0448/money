namespace Dhanman.Money.Application.Contracts.Customers;

public sealed class CreateCustomerRequest
{
    #region Properties
    public Guid UserId { get; set; }

    public Guid ClientId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string City { get; set; }
    #endregion

    #region Constructors
    public CreateCustomerRequest() => FirstName = string.Empty;
    #endregion

}
