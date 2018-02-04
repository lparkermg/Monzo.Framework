namespace Monzo.Framework.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a Merchant.
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        [JsonProperty("group_id")]
        public string GroupID { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the emoji.
        /// </summary>
        /// <value>The emoji.</value>
        public string Emoji { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public Address Address { get; set; }
    }
}