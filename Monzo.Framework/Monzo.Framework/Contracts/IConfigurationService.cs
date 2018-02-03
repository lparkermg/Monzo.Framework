namespace Monzo.Framework.Contracts
{
    /// <summary>
    /// Encapsulates logic for retrieving configuration values.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the environment variable.
        /// </summary>
        /// <returns>The envrionment variable value.</returns>
        /// <param name="name">env var name.</param>
        string GetEnvironmentVariable(string name);
    }
}