namespace dhanman.money.Application.Contracts.InvoiceDetails;

public sealed class InvoiceDetailListResponse
{
    #region Properties
    public IReadOnlyCollection<InvoiceDetailResponse> Items { get; }
    public string Cursor { get; }
    #endregion

    #region Constructors
    public InvoiceDetailListResponse(IReadOnlyCollection<InvoiceDetailResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }
    #endregion

}
