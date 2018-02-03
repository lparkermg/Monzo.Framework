namespace Monzo.Framework.Entities
{
    using System;

    /// <summary>
    /// Represents an Account.
    /// </summary>
    public class Account
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
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created.</value>
        public DateTime Created { get; set; }
    }
}