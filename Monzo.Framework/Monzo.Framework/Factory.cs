namespace Monzo.Framework
{
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Services;

    /// <summary>
    /// Factory responsible for generating service classes.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Creates a account service using the default monzo environment variable.
        /// </summary>
        /// <returns>The account service.</returns>
        public static IAccountService CreateAccountService() => new AccountService(new MonzoConfiguration());

        /// <summary>
        /// Creates a balance service using the default monzo environment variable.
        /// </summary>
        /// <returns>The balance service.</returns>
        public static IBalanceService CreateBalanceService() => new BalanceService(new MonzoConfiguration());

        /// <summary>
        /// Creates a transaction service using the default monzo environment variable.
        /// </summary>
        /// <returns>The transaction service.</returns>
        public static ITransactionService CreateTransactionService() => new TransactionService(new MonzoConfiguration());

        /// <summary>
        /// Creates a pot service using the default monzo environment variable.
        /// </summary>
        /// <returns>The pot service.</returns>
        public static IPotService CreatePotService() => new PotService(new MonzoConfiguration());
    }
}