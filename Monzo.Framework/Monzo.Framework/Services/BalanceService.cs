namespace Monzo.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;

    /// <inhertdoc />
    public class BalanceService : BaseService, IBalanceService
    {
        /// <summary>
        /// The API endpoint.
        /// </summary>
        public static string Endpoint = "https://api.monzo.com/balance";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.BalanceService"/> class.
        /// </summary>
        ///<param name="configuration">library configuration</param>
        public BalanceService(MonzoConfiguration configuration) 
            : base(configuration)
        {

        }

        /// <inhertdoc />
        public async Task<Balance> GetBalanceAsync(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var uri = new Uri(BalanceService.Endpoint + "?account_id=" + account.ID);
            var headers = new Dictionary<string, string>
            {
                {
                    "Authorization",
                    "Bearer " + this.authetication.AccessToken
                }
            };

            var rawJson = await this.httpService.GetAsync(uri, headers);
            return this.jsonService.Parse<Balance>(rawJson.Content.ReadAsStringAsync().Result);
        }
    }
}