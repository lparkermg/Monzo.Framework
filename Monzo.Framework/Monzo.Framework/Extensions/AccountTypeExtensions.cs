namespace Monzo.Framework.Extensions
{
    using System;
    using Monzo.Framework.Enums;

    /// <summary>
    /// Extensions for the <see cref="AccountType"/> enum.
    /// </summary>
    public static class AccountTypeExtensions
    {
        /// <summary>
        /// Gets the description of an Account Type.
        /// </summary>
        /// <returns>The description.</returns>
        /// <param name="accountType">Account type.</param>
        public static string GetDescription(this AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.UKRetail:
                    {
                        return "uk_retail";
                    }
                case AccountType.UKPrepaid:
                    {
                        return "uk_prepaid";
                    }
                default:
                    {
                        throw new InvalidOperationException("Invalid account type");
                    }
            }
        }
    }
}