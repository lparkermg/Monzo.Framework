namespace Monzo.Framework.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an Address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the address street.
        /// </summary>
        /// <value>The address street.</value>
        [JsonProperty("address")]
        public string AddressStreet { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public string Longitude { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        /// <value>The postcode.</value>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>The region.</value>
        public string Region { get; set; }
    }
}