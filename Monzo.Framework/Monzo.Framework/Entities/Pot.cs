namespace Monzo.Framework.Entities
{
    using System;

    /// <summary>
    /// Represents a Pot entity.
    /// </summary>
    public class Pot
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string ID { get; set; }  

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets the balance in pennies.
        /// </summary>
        /// <value>The balance.</value>
        public long Balance { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created.</value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated.</value>
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Monzo.Framework.Entities.Pot"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        public bool Deleted { get; set; }
    }
}