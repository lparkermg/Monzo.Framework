namespace Monzo.Framework.Services
{
    using System;
    using log4net;
    using Monzo.Framework.Contracts;

    /// <summary>
    /// Logger service
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        /// The Log4Net Logger
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Monzo.Framework.Services.Logger"/> class.
        /// </summary>
        /// <param name="log">injected Loger.</param>
        public Logger(ILog log)
        {
            this.log = log;
        }

        // <inheritdoc>
        public void Debug(string message)
        {
            this.log.Debug(message);
        }

        // <inheritdoc>
        public void Info(string message)
        {
            this.log.Info(message);
        }

        // <inheritdoc>
        public void Warn(string message)
        {
            this.log.Warn(message);
        }

        // <inheritdoc>
        public void Error(string message)
        {
            this.log.Error(message);
        }

        // <inheritdoc>
        public void Error(string message, Exception e)
        {
            this.log.Error(message, e);
        }

        // <inheritdoc>
        public void Fatal(string message)
        {
            this.log.Fatal(message);
        }

        // <inheritdoc>
        public void Fatal(string message, Exception e)
        {
            this.log.Fatal(message, e);
        }
    }
}