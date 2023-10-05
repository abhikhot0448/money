﻿using Dhanman.Money.Domain.Entities.Users;

namespace Dhanman.Money.Domain.Abstractions;

public interface IUserRepository
{
    #region Properties
    /// <summary>
    /// Checks if the specified email is unique among all existing users.
    /// </summary>
    /// <param name="email">The email to be checked.</param>
    /// <returns>True if the specified email is unique, otherwise false.</returns>
    Task<bool> IsEmailUniqueAsync(string email);

    /// <summary>
    /// Gets the user with the specified email.
    /// </summary>
    /// <param name="email">The user email.</param>
    /// <returns>The user with the specified email if it exists, otherwise null.</returns>
    Task<User?> GetByEmailAsync(string email);

    /// <summary>
    /// Inserts the specified user instance to the repository.
    /// </summary>
    /// <param name="user">The user instance to be inserted to the repository.</param>
    void Insert(User user);
    #endregion
}