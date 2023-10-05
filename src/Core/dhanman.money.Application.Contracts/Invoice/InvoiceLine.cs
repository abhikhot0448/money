namespace dhanman.money.Application.Contracts.Invoice;

public class InvoiceLine
{
    #region Properties
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }
    #endregion

    #region Constructors
    public InvoiceLine(string name, string description, decimal price, int quantity, decimal amount)
    {
        Name = name;
        Description = description;
        Price = price;
        Quantity = quantity;
        Amount = amount;
    }
    #endregion

}
