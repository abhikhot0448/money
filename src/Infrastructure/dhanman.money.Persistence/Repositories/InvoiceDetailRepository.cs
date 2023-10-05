using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoiceDetails;

namespace dhanman.money.Persistence.Repositories;

public class InvoiceDetailRepository : IInvoiceDetailRepository
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public InvoiceDetailRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public async Task<InvoiceDetail?> GetByIdAsync(Guid id)
  => await _dbContext.GetBydIdAsync<InvoiceDetail>(id);

    public void Insert(InvoiceDetail invoiceDetail) => _dbContext.Insert(invoiceDetail);
    #endregion

}
