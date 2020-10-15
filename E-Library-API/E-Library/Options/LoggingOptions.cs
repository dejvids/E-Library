using Serilog;
using Serilog.Events;

namespace E_Library.Options
{
    /// <summary>
    /// Logger configuraiton
    /// </summary>
    public class LoggingOptions
    {
        /// <summary>
        /// Configuration of console sink
        /// </summary>
        public LoggerOptions Console { get; set; }

        /// <summary>
        /// Configuration of file sink
        /// </summary>
        public FileLoggerOptions File { get; set; }
    }

    /// <summary>
    /// Basic logger config
    /// </summary>
    public class LoggerOptions
    {
        /// <summary>
        /// Enable or disable logging
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Minimal logging level 0-5
        /// </summary>
        public LogEventLevel MinLogLevel { get; set; }
    }

    /// <summary>
    /// File logger config
    /// </summary>
    public class FileLoggerOptions : LoggerOptions
    {
        /// <summary>
        /// Aboslute or relative path to logging file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Rolling file policy per day by default
        /// </summary>
        public RollingInterval RollingInterval { get; set; } = RollingInterval.Day;
    }
}
