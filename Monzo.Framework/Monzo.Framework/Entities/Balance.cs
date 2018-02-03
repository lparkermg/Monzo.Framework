namespace Monzo.Framework.Entities
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Balance.
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// Gets or sets the balance amount.
        /// </summary>
        /// <value>The balance amount.</value>
        [JsonProperty("balance")]
        public long BalanceAmount { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the spent today amount.
        /// </summary>
        /// <value>The spent today.</value>
        [JsonProperty("spend_today")]
        public long SpentToday { get; set; }
    }
}