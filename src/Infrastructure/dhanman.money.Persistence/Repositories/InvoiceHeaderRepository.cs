using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoiceHeaders;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Persistence.Repositories;

internal sealed class InvoiceHeaderRepository : IInvoiceHeaderRepository
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public InvoiceHeaderRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public async Task<InvoiceHeader?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<InvoiceHeader>(id);

    public void Insert(InvoiceHeader invoiceHeader) => _dbContext.Insert(invoiceHeader);

    public async Task<bool> IsInvoiceNumberUniqueAsync(string invoiceNumber)
         => !await _dbContext.Set<InvoiceHeader>().AnyAsync(user => user.InvoiceNumber.Equals(invoiceNumber));

    #endregion
}
