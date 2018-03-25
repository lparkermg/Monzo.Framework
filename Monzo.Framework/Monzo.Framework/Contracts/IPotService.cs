namespace Monzo.Framework.Contracts
{
    using System;
    using System.Threading.Tasks;
    using Monzo.Framework.Entities;

    /// <summary>
    /// Encapsulates logic to interfact with Pots.
    /// </summary>
    public interface IPotService
    {
        /// <summary>
        /// Gets the pots.
        /// </summary>
        /// <returns>The pots.</returns>
        Task<Pots> GetPotsAsync();

        /// <summary>
        /// Deposits a stated amount into the specified pot.
        /// </summary>
        /// <param name="potId">Pot to deposit into.</param>
        /// <param name="amount">Amount to deposit.</param>
        /// <returns>If the deposit was successful or not.</returns>
        Task<bool> DepositToPotAsync(string potId, long amount);

        /// <summary>
        /// Withdraws a stated amount into a target account from the specified pot.
        /// </summary>
        /// <param name="destinationAccountId">Account to deposit into.</param>
        /// <param name="potId">Pot to withdraw from.</param>
        /// <param name="amount">Amount to withdraw.</param>
        /// <returns>If the withdrawal was successful or not.</returns>
        Task<bool> WithdrawFromPotAsync(string destinationAccountId, string potId, long amount);
    }
}