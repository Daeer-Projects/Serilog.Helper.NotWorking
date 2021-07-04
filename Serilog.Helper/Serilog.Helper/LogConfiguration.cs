using Serilog.Helper.Enrichers;
using Serilog.Helper.LogTypes;

namespace Serilog.Helper
{
    public static class LogConfiguration
    {
        //public static ILogger GetLogger<T>() where T : ILogType
        //{
        //    return new LoggerConfiguration()
        //        .MinimumLevel.Debug()
        //        .Enrich.With<ThreadIdEnricher>()
        //        //.Enrich.WithProperty("LogType", nameof(ILogType))
        //        .WriteTo.Map("LogType", typeof(T).Name, (logType, writeTo) =>
        //            writeTo.File(@$"C:\Logs\Experiment\{logType}Log.log",
        //                rollingInterval: RollingInterval.Day,
        //                rollOnFileSizeLimit: true,
        //                outputTemplate:
        //                "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
        //        //.WriteTo.Map("LogType", "LocationType", (_, writeTo) =>
        //        //    writeTo.File(@"C:\Logs\Experiment\LocationTypeLog.log",
        //        //        rollingInterval: RollingInterval.Day,
        //        //        rollOnFileSizeLimit: true,
        //        //        outputTemplate:
        //        //        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
        //        //.WriteTo.Map("LogType", "OptionType", (_, writeTo) =>
        //        //    writeTo.File(@"C:\Logs\Experiment\OptionTypeLog.log",
        //        //        rollingInterval: RollingInterval.Day,
        //        //        rollOnFileSizeLimit: true,
        //        //        outputTemplate:
        //        //        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
        //        .CreateLogger();
        //}

        public static ILogger GetLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.With<ThreadIdEnricher>()
                //.Enrich.FromLogContext()
                //.Enrich.WithProperty("LogType", nameof(SystemType))
                //.Enrich.WithProperty("LogType", nameof(LocationType))
                //.Enrich.WithProperty("LogType", nameof(OptionType))
                //.Enrich.WithProperty("LogType", nameof(ILogType))
                .WriteTo.Map("LogType", nameof(SystemType), (logType, writeTo) =>
                    writeTo.File(@$"C:\Logs\Experiment\{logType}Log.log",
                        rollingInterval: RollingInterval.Day,
                        rollOnFileSizeLimit: true,
                        outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
                .WriteTo.Map("LogType", nameof(LocationType), (logType, writeTo) =>
                    writeTo.File(@$"C:\Logs\Experiment\{logType}Log.log",
                        rollingInterval: RollingInterval.Day,
                        rollOnFileSizeLimit: true,
                        outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
                .WriteTo.Map("LogType", nameof(OptionType), (logType, writeTo) =>
                    writeTo.File(@$"C:\Logs\Experiment\{logType}Log.log",
                        rollingInterval: RollingInterval.Day,
                        rollOnFileSizeLimit: true,
                        outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
                //.WriteTo.Map("LogType", "LocationType", (_, writeTo) =>
                //    writeTo.File(@"C:\Logs\Experiment\LocationTypeLog.log",
                //        rollingInterval: RollingInterval.Day,
                //        rollOnFileSizeLimit: true,
                //        outputTemplate:
                //        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
                //.WriteTo.Map("LogType", "OptionType", (_, writeTo) =>
                //    writeTo.File(@"C:\Logs\Experiment\OptionTypeLog.log",
                //        rollingInterval: RollingInterval.Day,
                //        rollOnFileSizeLimit: true,
                //        outputTemplate:
                //        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
                .CreateLogger();
        }
    }
}
