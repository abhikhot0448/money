using Dhanman.Money.Domain.Entities.Customers;

namespace Dhanman.Money.Domain.Abstractions;

public interface ICustomerRepository
{
    #region Methods

      Task<Customer?> GetByIdAsync(Guid id);

      Task<bool> IsEmailUniqueAsync(string email);

      void Insert(Customer customer);

      void Update(Customer customer);

      Task<bool> IsPhoneNumberUniqueAsync(string phoneNumber);

    #endregion

}
