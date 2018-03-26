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
        public async Task<Pot> DepositToPotAsync(string sourceAccountId, string potId, long amount, string deDuplicationId)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be less than zero");

            if(String.IsNullOrWhiteSpace(potId))
                throw new ArgumentException("Pot Id cannot be null, empty or whitespace.");

            if(String.IsNullOrWhiteSpace(sourceAccountId))
                throw new ArgumentException("Source Account Id cannot be null");

            var uri = new Uri($"{PotService.Endpoint}{potId}/deposit");
            var headers = new Dictionary<string, string>()
            {
                {"Authorization", $"Bearer {this.authetication.AccessToken}"},
                {"source_account_id",sourceAccountId },
                {"amount",amount.ToString() },
                {"dedupe_id",deDuplicationId }
            };

            var rawJson = await this.httpService.PutAsync(uri, headers);
            return this.jsonService.Parse<Pot>(rawJson.Content.ReadAsStringAsync().Result);
        }

        /// <inheritdoc />
        public async Task<bool> WithdrawFromPotAsync(string destinationAccountId, string potId, long amount, string deDuplicationId)
        {
            throw new NotImplementedException();
        }
    }
}