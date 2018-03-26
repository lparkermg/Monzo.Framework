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
        public static string Endpoint = "https://api.monzo.com/pots/";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.PotService"/> class.
        /// </summary>
        ///<param name="configuration">library configuration</param>
        public PotService(
            MonzoConfiguration configuration) 
            : base(configuration)
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
            return this.jsonService.Parse<Pots>(rawJson.Content.ReadAsStringAsync().Result);
        }

        /// <inheritdoc />
        public Task<bool> DepositToPotAsync(string potId, long amount)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<bool> WithdrawFromPotAsync(string destinationAccountId, string potId, long amount)
        {
            throw new NotImplementedException();
        }
    }
}