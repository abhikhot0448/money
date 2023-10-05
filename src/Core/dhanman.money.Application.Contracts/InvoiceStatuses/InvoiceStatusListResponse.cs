namespace dhanman.money.Application.Contracts.InvoiceStatuses;

public class InvoiceStatusListResponse
{
    #region Properties
    public IReadOnlyCollection<InvoiceStatusResponse> Items { get; }

    public string Cursor { get; }
    #endregion

    #region Constructors
    public InvoiceStatusListResponse(IReadOnlyCollection<InvoiceStatusResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }

    #endregion

}
