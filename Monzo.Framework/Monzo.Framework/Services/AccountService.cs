namespace Monzo.Framework.Services
{

    using System;
    using System.Collections.Generic;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;
    using Monzo.Framework.Enums;

    /// <inhertidoc />
    public class AccountService : IAccountService
    {
        private readonly IHttpService httpService;
        private readonly ILogger logger;

        public AccountService(IHttpService httpService, ILogger logger, Authentication authentication)
        {
            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService)); 
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
        }

        /// <inhertidoc />
        public List<Account> GetAccounts()
        {
            // url builder?

            throw new NotImplementedException();
        }

        /// <inhertidoc />
        public List<Account> GetAccounts(AccountType type)
        {
            throw new NotImplementedException();
        }
    }
}
