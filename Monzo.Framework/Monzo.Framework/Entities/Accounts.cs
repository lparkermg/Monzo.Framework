namespace Monzo.Framework.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a list of accounts.
    /// </summary>
    public class Accounts
    {
        /// <summary>
        /// Gets or sets the account collection.
        /// </summary>
        /// <value>The account collection.</value>
        [JsonProperty("accounts")]
        public List<Account> AccountCollection { get; set; }
    }
}