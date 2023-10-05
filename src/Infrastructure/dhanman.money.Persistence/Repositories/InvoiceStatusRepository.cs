using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoiceStatuses;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Persistence.Repositories;

public class InvoiceStatusRepository : IInvoiceStatusRepository
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public InvoiceStatusRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public async Task<InvoiceStatus?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<InvoiceStatus>(id);

    public void Insert(InvoiceStatus invoiceStatus) => _dbContext.Insert(invoiceStatus);

    public async Task<bool> IsInvoiceStatusUniqueAsync(string name)
           => !await _dbContext.Set<InvoiceStatus>().AnyAsync(user => user.Name == name);
    #endregion

}
