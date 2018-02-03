namespace Monzo.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;
    using Monzo.Framework.Enums;
    using Monzo.Framework.Extensions;

    /// <inhertidoc />
    public class AccountService : BaseService, IAccountService
    {       
        /// <summary>
        /// The API endpoint.
        /// </summary>
        public static string Endpoint = "https://api.monzo.com/accounts";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.AccountService"/> class.
        /// </summary>
        /// <param name="httpService">Http service.</param>
        /// <param name="logger">Logger.</param>
        /// <param name="jsonService">Json service.</param>
        /// <param name="authetication">Authetication.</param>
        public AccountService(
            IHttpService httpService, 
            ILogger logger, 
            IJSONService jsonService, 
            Authentication authetication) 
            : base(httpService, logger, jsonService, authetication)
        {
            
        }

        /// <inhertidoc />
        public async Task<Accounts> GetAccounts()
        {
            var uri = new Uri(AccountService.Endpoint);
            var headers = new Dictionary<string, string>()
            {
                {
                    "Authorization",
                    "Bearer " + this.authetication.AccessToken
                }
            };

            var rawJson = await this.httpService.Get(uri, headers);
            return this.jsonService.Parse<Accounts>(rawJson);
        }

        /// <inhertidoc />
        public async Task<Accounts> GetAccounts(AccountType type)
        {
            var uri = new Uri(AccountService.Endpoint + "?account_type=" + type.GetDescription());

            var headers = new Dictionary<string, string>()
            {
                {
                    "Authorization",
                    "Bearer " + this.authetication.AccessToken
                }
            };

            var rawJson = await this.httpService.Get(uri, headers);
            return this.jsonService.Parse<Accounts>(rawJson);
        }
    }
}
