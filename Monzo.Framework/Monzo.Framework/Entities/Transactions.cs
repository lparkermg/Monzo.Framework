namespace Monzo.Framework.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a List of Transactions.
    /// </summary>
    public class Transactions
    {
        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>The transactions.</value>
        [JsonProperty("transactions")]
        public List<Transaction> TransactionCollection { get; set; }
    }
}