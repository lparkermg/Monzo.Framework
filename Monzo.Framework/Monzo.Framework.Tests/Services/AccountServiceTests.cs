using System.Net.Http;

namespace Monzo.Framework.Tests.Services
{
    using System;
    using NUnit.Framework;
    using Moq;
    using Monzo.Framework.Services;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Monzo.Framework.Enums;
    using Monzo.Framework.Extensions;

    /// <summary>
    /// Tests for the <see cref="AccountService"/> class.
    /// </summary>
    [TestFixture]
    public class AccountServiceTests
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
        /// The http response.
        /// </summary>
        private HttpResponseMessage httpResponse;
        
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

            this.httpResponse = new HttpResponseMessage()
            {
                Content = new StringContent("json")
            };
        }

        /// <summary>
        /// Ensures when there are no accounts returned, an empty list is returned.
        /// </summary>
        [Test]
        public async Task GetAccountsAsync_NoAccounts_EmptyList()
        {
            this.httpService
                .Setup(x => x.GetAsync(new Uri(AccountService.Endpoint), this.headers))
                .Returns(Task.FromResult(httpResponse));

            this.jsonService
                .Setup(x => x.Parse<Accounts>("json"))
                .Returns(new Accounts() { AccountCollection = new List<Account>()});

            var result = await this.GetInstance().GetAccountsAsync();

            CollectionAssert.IsEmpty(result.AccountCollection);
            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Ensures when there are accounts found, they are returned.
        /// </summary>
        [Test]
        public async Task GetAccountsAsync_AccountsFound_AccountsReturned()
        {
            var returned = new Accounts();
            returned.AccountCollection = new List<Account>();
            returned.AccountCollection.Add(new Account() { ID = "1" , Created = new DateTime(2018,01,01), Description = "desc"});

            this.httpService
                .Setup(x => x.GetAsync(new Uri(AccountService.Endpoint), this.headers))
                .Returns(Task.FromResult(httpResponse));

            this.jsonService
                .Setup(x => x.Parse<Accounts>("json"))
                .Returns(returned);

            var service = this.GetInstance();
            var result = await service.GetAccountsAsync();

            Assert.AreEqual(1, result.AccountCollection.Count);
            Assert.AreEqual(returned.AccountCollection.First().ID, result.AccountCollection.First().ID);
            Assert.AreEqual(returned.AccountCollection.First().Created, result.AccountCollection.First().Created);
            Assert.AreEqual(returned.AccountCollection.First().Description, result.AccountCollection.First().Description);

            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Ensures when an account type is suppied, the account type is added to the uri and returning data is returned.
        /// </summary>      
        [Test]
        public async Task GetAccountsAsync_WithAccountType_AccountsReturned()
        {
            var returned = new Accounts();
            returned.AccountCollection = new List<Account>();
            returned.AccountCollection.Add(new Account() { ID = "1", Created = new DateTime(2018, 01, 01), Description = "desc" });

            this.httpService
                .Setup(x => x.GetAsync(new Uri(AccountService.Endpoint + "?account_type=" + AccountType.UKRetail.GetDescription() ), this.headers))
                .Returns(Task.FromResult(httpResponse));

            this.jsonService
                .Setup(x => x.Parse<Accounts>("json"))
                .Returns(returned);

            var result = await this.GetInstance().GetAccountsAsync(AccountType.UKRetail);

            Assert.AreEqual(1, result.AccountCollection.Count);
            Assert.AreEqual(returned.AccountCollection.First().ID, result.AccountCollection.First().ID);
            Assert.AreEqual(returned.AccountCollection.First().Created, result.AccountCollection.First().Created);
            Assert.AreEqual(returned.AccountCollection.First().Description, result.AccountCollection.First().Description);

            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        private AccountService GetInstance()
        {
            var config = new MonzoConfiguration()
            {
                httpService = this.httpService.Object,
                logger = this.logger.Object,
                jsonService = this.jsonService.Object,
                authService = this.authService.Object
            };

            return new AccountService(config);
        }
    }
}
