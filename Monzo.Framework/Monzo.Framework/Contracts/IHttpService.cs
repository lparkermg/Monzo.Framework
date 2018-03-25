namespace Monzo.Framework.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Encapsulates logic to interact with an external HTTP service.
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// GET the string response from the given uri and the given headers.
        /// </summary>
        /// <returns>The awaitable response.</returns>
        /// <param name="uri">URI to GET.</param>
        /// <param name="headers">Headers to add to the HTTP request.</param>
        Task<string> GetAsync(Uri uri, Dictionary<string, string> headers);
        
        /// <summary>
        /// Makes a PUT request to the given uri with the given headers.
        /// </summary>
        /// <param name="uri">URI to PUT.</param>
        /// <param name="headers">Headers to add to the HTTP request.</param>
        /// <returns>The awaitable response.</returns>
        Task<string> PutAsync(Uri uri, Dictionary<string, string> headers);

        /// <summary>
        /// Makes a POST request to the given uri with the given headers.
        /// </summary>
        /// <param name="uri">URI to POST.</param>
        /// <param name="headers">Headers to add to the HTTP request.</param>
        /// <returns>The awaitable response.</returns>
        Task<bool> PostAsync(Uri uri, Dictionary<string, string> headers);
    }
}