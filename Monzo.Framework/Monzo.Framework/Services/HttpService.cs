using System.Net.Http;

namespace Monzo.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;

    /// <inheritdoc />
    public sealed class HttpService : IHttpService
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger; 

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.HttpService"/> class.
        /// </summary>
        /// <param name="logger">injected logger.</param>
        public HttpService(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAsync(Uri uri, Dictionary<string, string> headers)
        {
            using(var client = new HttpClient())
            {
                foreach(var currentHeader in headers)
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation(currentHeader.Key, currentHeader.Value);
                }
                             
                return await client.GetAsync(uri);
            }
        }

        /// <inheritdoc />
        public Task<HttpResponseMessage> PutAsync(Uri uri, Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<HttpResponseMessage> PostAsync(Uri uri, Dictionary<string, string> headers)
        {
            throw new NotImplementedException();
        }
    }
}
