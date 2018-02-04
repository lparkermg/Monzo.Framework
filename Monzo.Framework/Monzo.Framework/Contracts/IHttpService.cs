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
    }
}