namespace Monzo.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;

    /// <inheritdoc />
    public class TransactionService : BaseService, ITransactionService
    {
        /// <summary>
        /// The API endpoint.
        /// </summary>
        public static string Endpoint = "https://api.monzo.com/transactions";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.BalanceService"/> class.
        /// </summary>
        /// <param name="httpService">Http service.</param>
        /// <param name="logger">Logger.</param>
        /// <param name="jsonService">Json service.</param>
        /// <param name="authetication">Authetication.</param>
        public TransactionService(
            IHttpService httpService,
            ILogger logger,
            IJSONService jsonService,
            Authentication authetication) 
            : base(httpService, logger, jsonService, authetication)
        {

        }

        /// <inheritdoc />
        public async Task<Transaction> GetTransactionAsync(string ID, bool expandMerchant = false)
        {
            if (string.IsNullOrWhiteSpace(ID))
            {
                throw new ArgumentNullException(nameof(ID));
            }
                       
            var uri = new Uri(TransactionService.Endpoint + ((expandMerchant) ? "?expand[]=merchant" : string.Empty));
            var headers = new Dictionary<string, string>
            {
                {
                    "Authorization",
                    "Bearer " + this.authetication.AccessToken
                }
            };

            var rawJson = await this.httpService.GetAsync(uri, headers);
            return this.jsonService.Parse<Transaction>(rawJson);
        }

        /// <inheritdoc />
        public async Task<Transactions> GetTransactionsAsync(Account account, bool expandMerchant = false)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var uri = new Uri(
                TransactionService.Endpoint + "?account_id=" + account.ID 
                    + ((expandMerchant) ? "&expand[]=merchant" : string.Empty));

            var headers = new Dictionary<string, string>();           
            headers.Add("Authorization", "Bearer " + this.authetication.AccessToken);

            var rawJson = await this.httpService.GetAsync(uri, headers);
            return this.jsonService.Parse<Transactions>(rawJson);
        }

        /// <inheritdoc />
        public async Task<Transactions> GetTransactionsByDateAsync(Account account, DateTime since, DateTime before, bool expandMerchant = false)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var uri = new Uri(
                TransactionService.Endpoint + "?account_id=" + account.ID 
                    + "&since=" + since.ToString()
                    + "&before=" + before.ToString()
                    + ((expandMerchant) ? "&expand[]=merchant" : string.Empty));

            var headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Bearer " + this.authetication.AccessToken);

            var rawJson = await this.httpService.GetAsync(uri, headers);
            return this.jsonService.Parse<Transactions>(rawJson);
        }
    }
}
