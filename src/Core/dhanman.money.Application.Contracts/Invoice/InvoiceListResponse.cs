namespace dhanman.money.Application.Contracts.Invoice;

public class InvoiceListResponse
{
    #region Properties
    public IReadOnlyCollection<InvoiceResponse> Items { get; }
    public string Cursor { get; }
    #endregion

    #region Constructors
    public InvoiceListResponse(IReadOnlyCollection<InvoiceResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }

    #endregion

}
