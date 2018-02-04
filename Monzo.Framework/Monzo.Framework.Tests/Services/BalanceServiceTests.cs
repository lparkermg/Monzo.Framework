namespace Monzo.Framework.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;
    using Monzo.Framework.Services;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="BalanceService"/> class.
    /// </summary>
    [TestFixture]
    public class BalanceServiceTests
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
        /// The auth service.
        /// </summary>
        private Mock<IAuthenticationService> authService;

        /// <summary>
        /// The auth object.
        /// </summary>
        private Authentication auth;

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
        /// Ensures when the balance is found, they are returned.
        /// </summary>
        [Test]
        public async Task GetBalanceAsync_BalanceFound_BalanceReturned()
        {
            var returned = new Balance()
            {
                BalanceAmount = 1000,
                Currency = "GBP",
                SpentToday = 1
            };

            var account = new Account()
            {
                ID = "123456"
            };
           

            this.httpService
                .Setup(x => x.GetAsync(new Uri(BalanceService.Endpoint + "?account_id=" + account.ID), this.headers))
                .Returns(Task.FromResult<string>("json"));

            this.jsonService
                .Setup(x => x.Parse<Balance>("json"))
                .Returns(returned);

            var result = await this.GetInstance().GetBalanceAsync(account);

            Assert.AreEqual(returned.BalanceAmount, result.BalanceAmount);
            Assert.AreEqual(returned.Currency, result.Currency);
            Assert.AreEqual(returned.SpentToday, result.SpentToday);

            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        private BalanceService GetInstance()
        {
            var config = new MonzoConfiguration()
            {
                httpService = this.httpService.Object,
                logger = this.logger.Object,
                jsonService = this.jsonService.Object,
                authService = this.authService.Object
            };

            return new BalanceService(config);
        }

    }
}
