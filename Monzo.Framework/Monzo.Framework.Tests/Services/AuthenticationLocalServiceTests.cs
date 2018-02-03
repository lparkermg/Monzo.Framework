namespace Monzo.Framework.Tests.Services
{
    using System;
    using NUnit.Framework;
    using Moq;
    using Monzo.Framework.Services;
    using Monzo.Framework.Contracts;

    /// <summary>
    /// Tests for the <see cref="AuthenticationLocalService"/> class.
    /// </summary>
    [TestFixture]
    public class AuthenticationLocalServiceTests
    {
        /// <summary>
        /// The config service.
        /// </summary>
        private Mock<IConfigurationService> configService;

        /// <summary>
        /// The logger.
        /// </summary>
        private Mock<ILogger> logger;

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.configService = new Mock<IConfigurationService>();
            this.logger = new Mock<ILogger>();
        }

        /// <summary>
        /// Ensures when the env var is not set, an invalid operation exception is thrown.
        /// </summary>
        [Test]
        [TestCase("")]
        [TestCase((string)null)]
        [TestCase("      ")]
        public void GetEnvironmentVariable_NotSet_InvalidOperationException(string accesstoken)
        {
            this.configService
                .Setup(x => x.GetEnvironmentVariable(AuthenticationLocalService.EnvironmentVariableName))
                .Returns(accesstoken);

            Assert.Throws<InvalidOperationException>(delegate
            {
                this.GetInstance().GetAuth();
            });           
        }

        /// <summary>
        /// Ensures when the env var is set, the auth object is returned.
        /// </summary>
        [Test]
        public void GetEnvironmentVariable_Set_AuthenticationObjectSet()
        {
            this.configService
                .Setup(x => x.GetEnvironmentVariable(AuthenticationLocalService.EnvironmentVariableName))
                .Returns("access_token");

            var auth = this.GetInstance().GetAuth();

            Assert.AreEqual("access_token", auth.AccessToken);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        private AuthenticationLocalService GetInstance()
        {
            return new AuthenticationLocalService(this.configService.Object, this.logger.Object);
        }
    }
}
