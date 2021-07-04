using System;
using Serilog.Context;

namespace Serilog.Helper.LogTypes
{
    public static class LogExtensions
    {
        public static ILogger AsSystemType(this ILogger logger)
        {
            //logger.ForContext("LogType", typeof(SystemType).FullName);
            logger.ForContext<SystemType>();
            return logger;
        }
        public static ILogger AsLocationType(this ILogger logger)
        {
            //logger.ForContext("LogType", nameof(LocationType));
            logger.ForContext<LocationType>();
            return logger;
        }
        public static ILogger AsOptionType(this ILogger logger)
        {
            //logger.ForContext("LogType", nameof(OptionType));
            logger.ForContext<OptionType>();
            return logger;
        }

        public static void AsType<T>(this ILogger logger, Action<ILogger> logMessage) where T : ILogType
        {
            using (LogContext.PushProperty("LogType", nameof(T)))
            {
                logMessage(logger);
            }
        }

        public static ILogger AsType<T>(this ILogger logger) where T : ILogType
        {
            logger.ForContext("LogType", nameof(T));
            return logger;
        }
    }
}
