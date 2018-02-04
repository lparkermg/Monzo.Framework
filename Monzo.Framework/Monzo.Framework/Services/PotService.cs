namespace Monzo.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;

    /// <inheritdoc />
    public class PotService : BaseService, IPotService
    {
        /// <summary>
        /// The API endpoint.
        /// </summary>
        public static string Endpoint = "https://api.monzo.com/pots/listV1";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.PotService"/> class.
        /// </summary>
        /// <param name="httpService">Http service.</param>
        /// <param name="logger">Logger.</param>
        /// <param name="jsonService">Json service.</param>
        /// <param name="authetication">Authetication.</param>
        public PotService(
            IHttpService httpService,
            ILogger logger,
            IJSONService jsonService,
            Authentication authetication) 
            : base(httpService, logger, jsonService, authetication)
        {

        }

        /// <inheritdoc />
        public async Task<Pots> GetPotsAsync()
        {
            var uri = new Uri(PotService.Endpoint);
            var headers = new Dictionary<string, string>()
            {
                {
                    "Authorization",
                    "Bearer " + this.authetication.AccessToken
                }
            };

            var rawJson = await this.httpService.GetAsync(uri, headers);
            return this.jsonService.Parse<Pots>(rawJson);
        }
    }
}