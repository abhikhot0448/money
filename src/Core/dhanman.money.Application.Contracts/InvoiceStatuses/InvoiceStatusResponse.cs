namespace dhanman.money.Application.Contracts.InvoiceStatuses;

public class InvoiceStatusResponse
{
    #region Properties
    public Guid Id { get; }
    public string Name { get; }
    public Guid ClientId { get; }
    public DateTime CreatedOnUtc { get; }
    #endregion

    #region Constructors
    public InvoiceStatusResponse(
     Guid id,
     string name,
     Guid clientId,
     DateTime createdOnUtc)
    {
        Id = id;
        Name = name;
        ClientId = clientId;
        CreatedOnUtc = createdOnUtc;
    }
    #endregion

}
