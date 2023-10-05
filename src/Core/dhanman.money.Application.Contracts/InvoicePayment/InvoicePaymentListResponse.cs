namespace dhanman.money.Application.Contracts.InvoicePayment;

public class InvoicePaymentListResponse
{
    #region Properties
    IReadOnlyCollection<InvoicePaymentResponse> Items { get; }
    public string Cursor { get; }
    #endregion

    #region Constructors
    public InvoicePaymentListResponse(IReadOnlyCollection<InvoicePaymentResponse> items, string cursor = "")
    {
        Items = items;
        Cursor = cursor;
    }
    #endregion

}
