namespace Monzo.Framework.Services
{
    using System;
    using Monzo.Framework.Contracts;
    using Monzo.Framework.Entities;

    public abstract class BaseService
    {
        /// <summary>
        /// The http service.
        /// </summary>
        protected readonly IHttpService httpService;

        /// <summary>
        /// The logger.
        /// </summary>
        protected readonly ILogger logger;

        /// <summary>
        /// The json service.
        /// </summary>
        protected readonly IJSONService jsonService;

        /// <summary>
        /// The authetication.
        /// </summary>
        protected readonly Authentication authetication;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.BaseService"/> class.
        /// </summary>
        /// <param name="configuration">Library configurations</param>
        protected BaseService(MonzoConfiguration configuration)
        {
            this.httpService = configuration.httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.logger = configuration.logger ?? throw new ArgumentNullException(nameof(logger));
            this.jsonService = configuration.jsonService ?? throw new ArgumentNullException(nameof(jsonService));
            this.authetication = configuration.GetAuth();

            if (string.IsNullOrWhiteSpace(authetication.AccessToken))
            {
                throw new ArgumentNullException(nameof(authetication.AccessToken));
            }
        }
    }
}