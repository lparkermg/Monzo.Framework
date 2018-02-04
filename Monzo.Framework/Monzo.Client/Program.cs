using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Monzo.Framework;
using Monzo.Framework.Services;

namespace Monzo.Client
{
    public class MainClass
    {
        public static void Main(string[] args)
        {           
            MonzoConfiguration configuration = new MonzoConfiguration();

            var accountService = new AccountService(configuration);
            var acc = accountService.GetAccountsAsync(Framework.Enums.AccountType.UKRetail);

            var account = acc.Result.AccountCollection.First();
            var transactionService = new TransactionService(configuration);

            Console.WriteLine(account.ID);
            Console.WriteLine(account.Description);
            Console.WriteLine(account.Created);
        }
    }
}
