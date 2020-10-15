using E_Library.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace E_Library.Extensions
{
    public static class LoggingExtensions
    {
        /// <summary>
        /// Name of config section dedicated to logger
        /// </summary>
        private const string LOGGING_SECTION = "Logging";

        /// <summary>
        /// Creates logger object based on configuration and registers it in IoC
        /// </summary>
        /// <param name="logging"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddLogger(this ILoggingBuilder logging, IConfiguration configuration)
        {
            var options = new LoggingOptions();
            configuration.Bind(LOGGING_SECTION, options);

            var logger = new LoggerConfiguration();

            if (options.Console?.Enabled == true)
                logger.WriteTo.Console(restrictedToMinimumLevel: options.Console.MinLogLevel);

            if (options.File?.Enabled == true)
            {
                string filePath = Environment.ExpandEnvironmentVariables(options.File.FilePath);
                logger = logger.WriteTo.File(filePath, rollingInterval: options.File.RollingInterval, restrictedToMinimumLevel: options.File.MinLogLevel);
            }

            logging.AddSerilog(logger.CreateLogger(), true);

            return logging;
        }
    }
}
