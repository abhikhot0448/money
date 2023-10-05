namespace dhanman.money.Application.Contracts.InvoiceDetails;

public class CreateInvoiceDetailRequest
{
    #region Properties
    public Guid UserId { get; set; }
    public Guid InvoiceHeaderId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }

    #endregion

    #region Constructors
    public CreateInvoiceDetailRequest() => Amount = decimal.One;
    #endregion

}
