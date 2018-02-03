namespace Monzo.Framework.Services
{

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;
    using Monzo.Framework.Enums;

    /// <inhertidoc />
    public class AccountService : IAccountService
    {
        /// <summary>
        /// The http service.
        /// </summary>
        private readonly IHttpService httpService;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The json service.
        /// </summary>
        private readonly IJSONService jsonService;

        /// <summary>
        /// The authetication.
        /// </summary>
        private readonly Authentication authetication;

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
        {
            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService)); 
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            this.jsonService = jsonService ?? throw new ArgumentNullException(nameof(jsonService)); 

            if (string.IsNullOrWhiteSpace(authetication.AccessToken))
            {
                throw new ArgumentNullException(nameof(authetication.AccessToken));
            }

            this.authetication = authetication;
        }

        /// <inhertidoc />
        public async Task<List<Account>> GetAccounts()
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
            return this.jsonService.Parse<List<Account>>(rawJson);
        }

        /// <inhertidoc />
        public async Task<List<Account>> GetAccounts(AccountType type)
        {
            throw new NotImplementedException();
        }
    }
}
