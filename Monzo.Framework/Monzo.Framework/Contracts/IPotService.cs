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
        /// <param name="sourceAccountId">Account Id to grab the funds from.</param>
        /// <param name="potId">Pot to deposit into.</param>
        /// <param name="amount">Amount to deposit.</param>
        /// <param name="deDuplicationId">Id to make sure that only one deposit is made when retrying.</param>
        /// <returns>The pot that the deposit was made into.</returns>
        Task<Pot> DepositToPotAsync(string sourceAccountId, string potId, long amount, string deDuplicationId);

        /// <summary>
        /// Withdraws a stated amount into a target account from the specified pot.
        /// </summary>
        /// <param name="destinationAccountId">Account to deposit into.</param>
        /// <param name="potId">Pot to withdraw from.</param>
        /// <param name="amount">Amount to withdraw.</param>
        /// <param name="deDuplicationId">Id to make sure that only one deposit is made when retrying.</param>
        /// <returns>The pot that the withdrawal was made from.</returns>
        Task<Pot> WithdrawFromPotAsync(string destinationAccountId, string potId, long amount, string deDuplicationId);
    }
}