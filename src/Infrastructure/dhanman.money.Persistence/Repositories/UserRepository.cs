using dhanman.money.Application.Abstractions.Data;
using dhanman.money.Domain.Abstractions;
using dhanman.money.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace dhanman.money.Persistence.Repositories;

internal class UserRepository : IUserRepository
{
    #region Properties
    private readonly IApplicationDbContext _dbContext;
    #endregion

    #region Constructors
    public UserRepository(IApplicationDbContext dbContext) => _dbContext = dbContext;
    #endregion

    #region Methods
    public async Task<bool> IsEmailUniqueAsync(string email)
      => !await _dbContext.Set<User>().AnyAsync(user => user.Email.Value == email);

    public async Task<User?> GetByEmailAsync(string email)
         => await _dbContext.Set<User>().FirstOrDefaultAsync(user => user.Email.Value == email);

    public void Insert(User user) => _dbContext.Set<User>().Add(user);
    #endregion
}
