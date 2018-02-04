namespace Monzo.Framework.Entities
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created.</value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the settled date.
        /// </summary>
        /// <value>The settled.</value>
        public DateTime? Settled { get; set; }
     
        /// <summary>
        /// Gets or sets the amount in pennies.
        /// </summary>
        /// <value>The amount.</value>
        public long Amount { get; set; }

        /// <summary>
        /// Gets or sets the account balance in pennies.
        /// </summary>
        /// <value>The account balance.</value>
        [JsonProperty("account_balance")]
        public long AccountBalance { get; set; }
                            
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Monzo.Framework.Entities.Transaction"/> is load.
        /// </summary>
        /// <value><c>true</c> if is load; otherwise, <c>false</c>.</value>
        [JsonProperty("is_load")]
        public bool IsLoad { get; set; }

        /// <summary>
        /// Gets or sets the merchant.
        /// </summary>
        /// <value>The merchant.</value>
        [JsonIgnore]
        public Merchant Merchant { get; set; }

        //public Merchant merchant {get;set;}
    }
}