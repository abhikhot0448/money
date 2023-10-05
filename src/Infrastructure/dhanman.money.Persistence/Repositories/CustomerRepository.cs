using Dhanman.Money.Application.Abstractions.Data;
using Dhanman.Money.Domain.Abstractions;
using Dhanman.Money.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace Dhanman.Money.Persistence.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public CustomerRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public async Task<Customer?> GetByIdAsync(Guid id) => await _dbContext.GetBydIdAsync<Customer>(id);

    public void Insert(Customer customer) => _dbContext.Insert(customer);

    public void Update(Customer customer) => _dbContext.Update(customer);

    public async Task<bool> IsEmailUniqueAsync(string email)
           => !await _dbContext.Set<Customer>().AnyAsync(user => user.Email.Equals(email));

    public async Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber)
         => !await _dbContext.Set<Customer>().AnyAsync(user => user.PhoneNumber.Equals(phoneNumber));
    #endregion

}
