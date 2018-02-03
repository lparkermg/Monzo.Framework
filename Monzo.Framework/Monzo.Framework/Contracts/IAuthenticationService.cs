namespace Monzo.Framework.Contracts
{
    using Monzo.Framework.Entities;

    /// <summary>
    /// Encapsulates logic for authenticating with the API.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Gets the Auth object.
        /// </summary>
        /// <returns>The auth obj.</returns>
        Authentication GetAuth();
    }
}