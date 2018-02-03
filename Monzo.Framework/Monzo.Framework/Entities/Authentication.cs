namespace Monzo.Framework.Entities
{
    /// <summary>
    /// Represents authentication with the API.
    /// </summary>
    public struct Authentication
    {
        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }
    }
}