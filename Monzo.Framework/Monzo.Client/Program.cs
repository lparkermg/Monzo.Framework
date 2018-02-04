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

            var potservice = new PotService(configuration);
            potservice.GetPotsAsync()

            var transactions = transactionService.GetTransactionsAsync(account, false);
           
            //var result = transactionService.GetTransactionsAsync(account, false).Result;
            var result2 = transactionService.GetTransactionsByDateAsync(account, new DateTime(2018, 01, 05), new DateTime(2018, 01, 10), false).Result;

            var balanceservice = new BalanceService(configuration);
            var balance = balanceservice.GetBalanceAsync(account).Result;

            Console.WriteLine(balance.BalanceAmount);

            Console.WriteLine(result2);

            //Console.WriteLine(balanceService.GetBalanceAsync(acc.Result.AccountCollection.First()).Result.BalanceAmount);
        }
    }
}
