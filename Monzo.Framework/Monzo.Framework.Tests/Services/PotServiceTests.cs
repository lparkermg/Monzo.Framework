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
    /// Tests for the <see cref="PotService"/> class.
    /// </summary>
    [TestFixture]
    public class PotServiceTests
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
        /// Ensures when there are no pots returned, an empty list is returned.
        /// </summary>
        [Test]
        public async Task GetPotsAsync_NoPots_EmptyList()
        {
            this.httpService
                .Setup(x => x.GetAsync(new Uri(PotService.Endpoint), this.headers))
                .Returns(Task.FromResult<string>("json"));

            this.jsonService
                .Setup(x => x.Parse<Pots>("json"))
                .Returns(new Pots() { PotCollection = new List<Pot>() });

            var result = await this.GetInstance().GetPotsAsync();

            CollectionAssert.IsEmpty(result.PotCollection);
            this.httpService.VerifyAll();
            this.jsonService.VerifyAll();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        private PotService GetInstance()
        {
            var config = new MonzoConfiguration()
            {
                httpService = this.httpService.Object,
                logger = this.logger.Object,
                jsonService = this.jsonService.Object,
                authService = this.authService.Object
            };

            return new PotService(config);
        }
    }
}
