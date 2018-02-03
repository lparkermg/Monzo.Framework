namespace Monzo.Framework.Contracts
{
    using System;

    /// <summary>
    /// Encapsualtes logging behaviour.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log a message at DEBUG level.
        /// </summary>
        /// <param name="message">message to log.</param>
        void Debug(string message);

        /// <summary>
        /// Log a message at INFO level.
        /// </summary>
        /// <param name="message">message to log..</param>
        void Info(string message);

        /// <summary>
        /// Log a message at WARN level.
        /// </summary>
        /// <param name="message">message to log..</param>
        void Warn(string message);

        /// <summary>
        /// Log a message at ERROR level.
        /// </summary>
        /// <param name="message">message to log.</param>
        void Error(string message);

        /// <summary>
        /// Log a message at ERROR level with exception.
        /// </summary>
        /// <param name="message">message to log..</param>
        /// <param name="e">The exception to log.</param>
        void Error(string message, Exception e);

        /// <summary>
        /// Log a message at FATAL level.
        /// </summary>
        /// <param name="message">message to log..</param>
        void Fatal(string message);

        /// <summary>
        /// Log a message at FATAL level with exception.
        /// </summary>
        /// <param name="message">message to log.</param>
        /// <param name="e">The exception to log.</param>
        void Fatal(string message, Exception e);
    }
}