namespace Monzo.Framework.Contracts
{
    using System.Collections.Generic;
    using Monzo.Framework.Entities;
    using Monzo.Framework.Enums;

    /// <summary>
    /// Encapsulates logic to interact with Account objects.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Gets all Accounts.
        /// </summary>
        /// <returns>The accounts.</returns>
        List<Account> GetAccounts();

        /// <summary>
        /// Gets the accounts fitered by the passed account type.
        /// </summary>
        /// <returns>The accounts.</returns>
        /// <param name="type">account type to filter on.</param>
        List<Account> GetAccounts(AccountType type);
    }
}