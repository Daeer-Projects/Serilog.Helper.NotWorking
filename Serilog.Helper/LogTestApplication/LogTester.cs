using System;
using Serilog;
using Serilog.Helper;
using Serilog.Helper.LogTypes;

namespace LogTestApplication
{
    public class LogTester
    {
        public LogTester()
        {
            _logger = LogConfiguration.GetLogger();
        }

        private readonly ILogger _logger;

        internal void LogSystemMessage(string message)
        {
            //var logger = LogConfiguration.GetLogger<SystemType>();
            //_logger.Information($"{message} {{LogType}}", nameof(SystemType));
            //_logger.AsSystemType().Information(message);
            _logger.AsType<SystemType>((l) => l.Information(message));
            //_logger.AsType<SystemType>().Information(message);
        }

        internal void LogLocationMessage(string message)
        {
            //var logger = LogConfiguration.GetLogger<LocationType>();
            //_logger.AsLocationType().Information(message);
            //_logger.AsLocationType().Error($"{message} - {new Exception(message)}");
            //_logger.AsType<LocationType>().Information(message);
            //_logger.AsType<LocationType>().Error($"{message} - {new Exception(message)}");

            _logger.AsType<LocationType>((l) => l.Information(message));
            _logger.AsType<LocationType>((l) => l.Error($"{message} - {new Exception(message)}"));
        }

        internal void LogOptionMessage(string message)
        {
            //var logger = LogConfiguration.GetLogger<OptionType>();
            //_logger.AsOptionType().Debug(message);
            //_logger.AsType<OptionType>().Debug(message);

            _logger.AsType<OptionType>((l) => l.Debug(message));
        }

        //internal void LogSimpleMessage(string message)
        //{
        //    var logger = LogConfiguration.GetLogger<SystemType>();
        //    var wrappedMessage = $"{message} {{LogType}}";
        //    _logger.Information(wrappedMessage, "Another");
        //}
    }
}
