namespace Monzo.Framework.Contracts
{
    using System;
    using System.Threading.Tasks;
    using Monzo.Framework.Entities;

    /// <summary>
    /// Encapsulates logic for retreiving Transactions.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Gets a single transaction.
        /// </summary>
        /// <param name="ID">ID of the transaction.</param>
        /// <param name="expandMerchant">Flag indicating if the merchant data should also be returned.</param>
        /// <returns>The transaction.</returns>
        Task<Transaction> GetTransactionAsync(string ID, bool expandMerchant = false);

        /// <summary>
        /// Gets multipe transactions related to an <see cref="Account"/>.
        /// </summary>
        /// <returns>The transactions list.</returns>
        /// <param name="account">account to find transactions on.</param>
        /// <param name="expandMerchant">If set to <c>true</c> expand merchant.</param>
        Task<Transactions> GetTransactionsAsync(Account account, bool expandMerchant = false);

        /// <summary>
        /// Gets multiple tranactions realted to an <see cref="Account"/>,
        /// filtered by the passed since date and before date.
        /// </summary>
        /// <returns>The transactions by date async.</returns>
        /// <param name="account">account to find transactions on.</param>
        /// <param name="since">all transactions since.</param>
        /// <param name="before">all transactions before.</param>
        /// <param name="expandMerchant">If set to <c>true</c> expand merchant.</param>
        Task<Transactions> GetTransactionsByDateAsync(Account account, DateTime since, DateTime before, bool expandMerchant = false);
    }
}