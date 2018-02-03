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
        /// <param name="httpService">Http service.</param>
        /// <param name="logger">Logger.</param>
        /// <param name="jsonService">Json service.</param>
        /// <param name="authetication">Authetication.</param>
        protected BaseService(
           IHttpService httpService,
           ILogger logger,
           IJSONService jsonService,
           Authentication authetication)
        {
            this.httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.jsonService = jsonService ?? throw new ArgumentNullException(nameof(jsonService));

            if (string.IsNullOrWhiteSpace(authetication.AccessToken))
            {
                throw new ArgumentNullException(nameof(authetication.AccessToken));
            }

            this.authetication = authetication;
        }
    }
}