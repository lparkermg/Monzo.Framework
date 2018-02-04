using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
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


            var accountService = new AccountService(httpService, logger, jsonservice, authservice.GetAuth());
            var acc = accountService.GetAccountsAsync(Framework.Enums.AccountType.UKRetail);



            var account = acc.Result.AccountCollection.First();
            var transactionService = new TransactionService(httpService, logger, jsonservice, authservice.GetAuth());

            var result = transactionService.GetTransactionsAsync(account, false).Result;

            Console.WriteLine(result);

            //Console.WriteLine(balanceService.GetBalanceAsync(acc.Result.AccountCollection.First()).Result.BalanceAmount);
        }
    }
}
