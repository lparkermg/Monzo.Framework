namespace Monzo.Framework.Contracts
{
    using System;
    using System.Threading.Tasks;
    using Monzo.Framework.Entities;

    /// <summary>
    /// Encapsulates logic to interfact with Pots.
    /// </summary>
    public interface IPotService
    {
        /// <summary>
        /// Gets the pots.
        /// </summary>
        /// <returns>The pots.</returns>
        Task<Pots> GetPots();
    }
}