namespace dhanman.money.Application.Contracts.InvoiceHeaders;


public class InvoiceHeaderListResponse
{
    #region Properties
    public IReadOnlyCollection<InvoiceHeaderResponse> Items { get; }

    public string Cursor { get; }
    #endregion

    #region Constructors
    public InvoiceHeaderListResponse(IReadOnlyCollection<InvoiceHeaderResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }

    #endregion

}

