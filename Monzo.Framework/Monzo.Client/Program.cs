using System;
using System.Collections.Generic;
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



            var accountservice = new AccountService(httpService, logger, jsonservice, authservice.GetAuth());

            var account = accountservice.GetAccounts(Framework.Enums.AccountType.UKRetail).Result;

            foreach(var current in account.AccountCollection)
            {
                Console.WriteLine(current.ID);
            }
        }
    }
}
