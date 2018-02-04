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
            var log = LogManager.GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            var configService = new ConfigurationService();
            var logger = new Logger(log);
            var jsonservice = new JSONService(logger);
            var httpService = new HttpService(logger);
            var authservice = new AuthenticationLocalService(configService, logger);

            MonzoConfiguration configuration = new MonzoConfiguration();

            var accountService = new AccountService(configuration);
            var acc = accountService.GetAccountsAsync(Framework.Enums.AccountType.UKRetail);

            var account = acc.Result.AccountCollection.First();
            var transactionService = new TransactionService(configuration);

            //var result = transactionService.GetTransactionsAsync(account, false).Result;
            var result2 = transactionService.GetTransactionsByDateAsync(account, new DateTime(2018, 01, 05), new DateTime(2018, 01, 10), false).Result;

            Console.WriteLine(result2);

            //Console.WriteLine(balanceService.GetBalanceAsync(acc.Result.AccountCollection.First()).Result.BalanceAmount);
        }
    }
}
