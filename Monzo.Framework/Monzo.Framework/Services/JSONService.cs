namespace Monzo.Framework.Services
{
    using System;
    using Monzo.Framework.Contracts;
    using Newtonsoft.Json;

    /// <inheritdoc />
    public class JSONService : IJSONService
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.JSONService"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public JSONService(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public T Parse<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);           
        }

        /// <inheritdoc />
        public string Parse<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
