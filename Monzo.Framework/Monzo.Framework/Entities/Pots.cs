namespace Monzo.Framework.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a list of Pots.
    /// </summary>
    public class Pots
    {
        /// <summary>
        /// Gets or sets the pot collection.
        /// </summary>
        /// <value>The pot collection.</value>
        [JsonProperty("pots")]
        public List<Pot> PotCollection { get; set; }
    }
}