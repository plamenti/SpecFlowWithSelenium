using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;

namespace SeleniumTaskAmazon.Helpers
{
    public static class LoggingManager
    {
        
        private static Logger logger;

        static LoggingManager()
        {
            logger = InilializeLogger();
        }

        public static void LogInfo(string message)
        {
            logger.Log(LogLevel.Info, message);
        }

        public static void LogDebug(string message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public static void LogError(string message)
        {
            logger.Log(LogLevel.Error, message);
        }

        private static Logger InilializeLogger()
        {
            LoggingConfiguration config = new LoggingConfiguration();
            string logPath = IOManager.CreateLogsDirectory();
            string logFileName = $"logged_info_at_{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}";

            var target =
                new FileTarget
                {
                    FileName = Path.Combine(logPath, logFileName) + ".log"
                };

            config.AddTarget("logfile", target);

            var fileLoggingRule = new LoggingRule("*", LogLevel.Debug, target);
            config.LoggingRules.Add(fileLoggingRule);
            LogManager.Configuration = config;

            return LogManager.GetCurrentClassLogger();
        }
    }
}
