namespace Monzo.Framework.Services
{
    using System;
    using Monzo.Framework.Contracts;

    /// <inheritdoc />
    public sealed class ConfigurationService : IConfigurationService
    {
        /// <inheritdoc />
        public string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}