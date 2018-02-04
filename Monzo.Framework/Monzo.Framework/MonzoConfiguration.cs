namespace Monzo.Framework
{
    using log4net;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Services;

    /// <summary>
    /// Monzo library configuration options.
    /// </summary>
    public sealed class MonzoConfiguration
    {
        /// <summary>
        /// Gets or sets the http service.
        /// </summary>
        /// <value>The http service.</value>
        public IHttpService httpService { get; set; }

        /// <summary>
        /// Gets or sets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger logger { get; set; }

        /// <summary>
        /// Gets or sets the config service.
        /// </summary>
        /// <value>The config service.</value>
        public IConfigurationService configService { get; set; }

        /// <summary>
        /// Gets or sets the json service.
        /// </summary>
        /// <value>The json service.</value>
        public IJSONService jsonService { get; set; }

        /// <summary>
        /// Gets or sets the auth service.
        /// </summary>
        /// <value>The auth service.</value>
        public IAuthenticationService authService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.MonzoConfiguration"/> class.
        /// </summary>
        public MonzoConfiguration()
        {
            var log = LogManager.GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            this.configService = new ConfigurationService();
            this.logger = new Logger(log);
            this.jsonService = new JSONService(logger);
            this.httpService =  new HttpService(logger);
            this.authService = new AuthenticationLocalService(configService, logger);
        }
    }
}