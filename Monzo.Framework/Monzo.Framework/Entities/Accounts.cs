namespace Monzo.Framework.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Accounts
    {
        [JsonProperty("accounts")]
        public List<Account> AccountCollection { get; set; }
    }
}