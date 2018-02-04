
namespace Monzo.Framework.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;
    using Monzo.Framework.Services;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionServiceTests
    {
        /// <summary>
        /// The http service.
        /// </summary>
        private Mock<IHttpService> httpService;

        /// <summary>
        /// The json service.
        /// </summary>
        private Mock<IJSONService> jsonService;

        /// <summary>
        /// The logger.
        /// </summary>
        private Mock<ILogger> logger;

        /// <summary>
        /// The auth object.
        /// </summary>
        private Authentication auth;

        /// <summary>
        /// The auth service.
        /// </summary>
        private Mock<IAuthenticationService> authService;

        /// <summary>
        /// The headers.
        /// </summary>
        private Dictionary<string, string> headers;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.httpService = new Mock<IHttpService>();
            this.jsonService = new Mock<IJSONService>();
            this.logger = new Mock<ILogger>();

            this.auth = new Authentication() { AccessToken = "test_access_token" };
            this.authService = new Mock<IAuthenticationService>();
            this.authService.Setup(x => x.GetAuth()).Returns(auth);

            this.headers = new Dictionary<string, string>()
            {
                {
                    "Authorization",
                    "Bearer " + this.auth.AccessToken
                }
            };
        }

        /// <summary>
        /// Ensures when a transaction is retrieved with false merchant, the correct url is called
        /// and the transaction is returned.
        /// </summary>
        [Test]
        public async Task GetTransactionAsync_RetievedAndMerchantFalse_Returned()
        {
            var returned = new Transaction()
            {
                ID = "1234",
                Notes = "this is a transaction"
            };

            this.httpService
                .Setup(x => x.GetAsync(new Uri(TransactionService.Endpoint), this.headers))
                .Returns(Task.FromResult<string>("json"));

            this.jsonService
                .Setup(x => x.Parse<Transaction>("json"))
                .Returns(returned);

            var result = await this.GetInstance().GetTransactionAsync(returned.ID, false);

            Assert.AreEqual(returned.ID, result.ID);
            Assert.AreEqual(returned.Notes, result.Notes);

            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Ensures when a transaction is retrieved with true merchant, the correct url is called
        /// and the transaction is returned.
        /// </summary>
        [Test]
        public async Task GetTransactionAsync_RetievedAndMerchantTrue_Returned()
        {
            var returned = new Transaction()
            {
                ID = "1234",
                Notes = "this is a transaction",
                Merchant = new Merchant()
                {
                    Name = "merchant"
                }
            };

            this.httpService
                .Setup(x => x.GetAsync(new Uri(TransactionService.Endpoint + "?expand[]=merchant"), this.headers))
                .Returns(Task.FromResult<string>("json"));

            this.jsonService
                .Setup(x => x.Parse<Transaction>("json"))
                .Returns(returned);

            var result = await this.GetInstance().GetTransactionAsync(returned.ID, true);

            Assert.AreEqual(returned.ID, result.ID);
            Assert.AreEqual(returned.Notes, result.Notes);
            Assert.AreSame(returned.Merchant.Name, result.Merchant.Name);

            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Ensures when transactions are retrieved with false merchant, the correct url is called
        /// and the transactions are returned.
        /// </summary>
        [Test]
        public async Task GetTransactionsAsync_RetievedAndMerchantFalse_Returned()
        {
            var returned = new Transactions()
            {
                TransactionCollection = new List<Transaction>()
                {
                    new Transaction()
                    {
                        ID = "1234",
                        Notes = "this is a transaction"
                    }
                }
            };

            var account = new Account { ID = "1" };
            var url = new Uri(TransactionService.Endpoint + "?account_id=" + account.ID);

            this.httpService
                .Setup(x => x.GetAsync(url, this.headers))
                .Returns(Task.FromResult<string>("json"));

            this.jsonService
                .Setup(x => x.Parse<Transactions>("json"))
                .Returns(returned);

            var result = await this.GetInstance().GetTransactionsAsync(account, false);

            CollectionAssert.IsNotEmpty(result.TransactionCollection);
            Assert.AreEqual(returned.TransactionCollection.First().ID, result.TransactionCollection.First().ID);
            Assert.AreEqual(returned.TransactionCollection.First().Notes, result.TransactionCollection.First().Notes);

            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Ensures when transactions are retrieved with true merchant, the correct url is called
        /// and the transactions are returned.
        /// </summary>
        [Test]
        public async Task GetTransactionsAsync_RetievedAndMerchantTrue_Returned()
        {
            var returned = new Transactions()
            {
                TransactionCollection = new List<Transaction>()
                {
                    new Transaction()
                    {
                        ID = "1234",
                        Notes = "this is a transaction",
                        Merchant = new Merchant()
                        {
                            ID = "mID"
                        }
                    }
                }
            };

            var account = new Account { ID = "1" };
            var url = new Uri(TransactionService.Endpoint + "?account_id=" + account.ID + "&expand[]=merchant");

            this.httpService
                .Setup(x => x.GetAsync(url, this.headers))
                .Returns(Task.FromResult<string>("json"));

            this.jsonService
                .Setup(x => x.Parse<Transactions>("json"))
                .Returns(returned);

            var result = await this.GetInstance().GetTransactionsAsync(account, true);

            CollectionAssert.IsNotEmpty(result.TransactionCollection);
            Assert.AreEqual(returned.TransactionCollection.First().ID, result.TransactionCollection.First().ID);
            Assert.AreEqual(returned.TransactionCollection.First().Notes, result.TransactionCollection.First().Notes);
            Assert.AreEqual(returned.TransactionCollection.First().Merchant.ID, result.TransactionCollection.First().Merchant.ID);

            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        private TransactionService GetInstance()
        {
            var config = new MonzoConfiguration()
           {
               httpService = this.httpService.Object,
               logger = this.logger.Object,
               jsonService = this.jsonService.Object,
               authService = this.authService.Object
           };

            return new TransactionService(config);
        }
    }
}
