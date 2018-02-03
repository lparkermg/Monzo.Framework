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
        public async Task<string> Get(Uri uri, Dictionary<string, string> headers)
        {
            using(var client = new WebClient())
            {
                foreach(var currentHeader in headers)
                {
                    client.Headers.Set(currentHeader.Key, currentHeader.Value);
                }
                             
                return await client.DownloadStringTaskAsync(uri.AbsolutePath);
            }
        }
    }
}
