using dhanman.money.Domain.Entities.Customers;

namespace dhanman.money.Domain.Abstractions;

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
