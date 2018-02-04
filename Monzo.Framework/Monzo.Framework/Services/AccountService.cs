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
        /// <param name="config">Library configurations</param>
        public AccountService(MonzoConfiguration config) 
            : base(config)
        {
            
        }

        /// <inhertidoc />
        public async Task<Accounts> GetAccountsAsync()
        {
            var uri = new Uri(AccountService.Endpoint);
            var headers = new Dictionary<string, string>()
            {
                {
                    "Authorization",
                    "Bearer " + this.authetication.AccessToken
                }
            };

            var rawJson = await this.httpService.GetAsync(uri, headers);
            return this.jsonService.Parse<Accounts>(rawJson);
        }

        /// <inhertidoc />
        public async Task<Accounts> GetAccountsAsync(AccountType type)
        {
            var uri = new Uri(AccountService.Endpoint + "?account_type=" + type.GetDescription());

            var headers = new Dictionary<string, string>()
            {
                {
                    "Authorization",
                    "Bearer " + this.authetication.AccessToken
                }
            };

            var rawJson = await this.httpService.GetAsync(uri, headers);
            return this.jsonService.Parse<Accounts>(rawJson);
        }
    }
}
