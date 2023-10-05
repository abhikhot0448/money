namespace dhanman.money.Domain.Entities.Customers;

public class Address
{
    #region Properties
    public string StreetAddress { get; protected set; }
    public string City { get; protected set; }
    public string State { get; protected set; }
    public string PostalCode { get; protected set; }
    #endregion

    #region Constructors
    public Address(string streetAddress, string city, string state, string postalCode)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        PostalCode = postalCode;
    }
    #endregion

}
