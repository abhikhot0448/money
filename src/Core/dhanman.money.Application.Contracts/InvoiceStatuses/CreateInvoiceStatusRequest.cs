namespace dhanman.money.Application.Contracts.InvoiceStatuses;

public class CreateInvoiceStatusRequest
{
    #region Properties
    public Guid UserId { get; set; }

    public Guid ClientId { get; set; }

    public string Name { get; set; }
    #endregion

    #region Constructors
    public CreateInvoiceStatusRequest() => Name = string.Empty;
    #endregion

}
