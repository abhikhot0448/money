namespace dhanman.money.Application.Contracts.InvoiceDetails;

public sealed class InvoiceDetailResponse
{

    #region Properties
    public Guid Id { get; }
    public Guid InvoiceHeaderId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedOnUtc { get; }
    #endregion

    #region Constructors
    public InvoiceDetailResponse
        (Guid id,
    Guid invoiceHeaderId,
    string name,
    string description,
    decimal price,
    int quantity,
    decimal amount,
    DateTime createdOnUtc)
    {
        Id = id;
        InvoiceHeaderId = invoiceHeaderId;
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;
        CreatedOnUtc = createdOnUtc;
    }
    #endregion

}
