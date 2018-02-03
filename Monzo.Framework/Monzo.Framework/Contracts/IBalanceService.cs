namespace Monzo.Framework.Contracts
{
    using System.Threading.Tasks;
    using Monzo.Framework.Entities;

    /// <summary>
    /// Encapsulates logic to interact with a Balance.
    /// </summary>
    public interface IBalanceService
    {
        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <param name="account">Account to get balance for.</param>
        /// <returns>The balance.</returns>
        Task<Balance> GetBalance(Account account);
    }
}