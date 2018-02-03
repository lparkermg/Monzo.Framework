namespace Monzo.Framework.Services
{
    using System;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;

    /// <summary>
    /// Authentication logic for retrieving the access token from LOCAL.
    /// </summary>
    public class AuthenticationLocalService : IAuthenticationService
    {
        /// <summary>
        /// The config service.
        /// </summary>
        private readonly IConfigurationService configService;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// The name of the environment variable.
        /// </summary>
        public static string EnvironmentVariableName = "MONZO";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.AuthenticationLocalService"/> class.
        /// </summary>
        /// <param name="configService">Injected Config service.</param>
        /// <param name="logger">injected logger.</param>
        public AuthenticationLocalService(IConfigurationService configService, ILogger logger)
        {
            this.configService = configService ?? throw new ArgumentNullException(nameof(configService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inhertdoc />
        public Authentication GetAuth()
        {
            var accessToken = this.configService.GetEnvironmentVariable(AuthenticationLocalService.EnvironmentVariableName);

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new InvalidOperationException(AuthenticationLocalService.EnvironmentVariableName + " not set");
            }

            this.logger.Debug("access token retrieved");
            return new Authentication() { AccessToken = accessToken };
        }
    }
}
