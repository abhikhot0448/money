namespace Dhanman.Money.Application.Contracts.Customers;

public sealed class CustomerListResponse
{
    #region Properties
    public IReadOnlyCollection<CustomerResponse> Items { get; }

     public string Cursor { get; }

    #endregion

    #region Constructors
    public CustomerListResponse(IReadOnlyCollection<CustomerResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }
    #endregion


   
}
