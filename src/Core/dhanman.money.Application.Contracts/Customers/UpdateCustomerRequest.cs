namespace dhanman.money.Application.Contracts.Customers;

public sealed class UpdateCustomerRequest
{
    #region Constructor
    public UpdateCustomerRequest() => FirstName = string.Empty;

    #endregion

    #region Properties

    public Guid CustomerId { get; set; }

    public Guid ClientId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string City { get; set; }

    #endregion

}
