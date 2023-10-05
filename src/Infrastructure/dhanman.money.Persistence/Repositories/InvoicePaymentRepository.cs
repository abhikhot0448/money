using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.InvoicePayments;

namespace dhanman.money.Persistence.Repositories;

internal sealed class InvoicePaymentRepository : IInvoicePaymentRepository
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public InvoicePaymentRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public async Task<InvoicePayment?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<InvoicePayment>(id);

    public void Insert(InvoicePayment invoicePayment) => _dbContext.Insert(invoicePayment);
    #endregion

}
