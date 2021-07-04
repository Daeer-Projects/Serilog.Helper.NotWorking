using Serilog.Core;
using Serilog.Events;
using Serilog.Helper.LogTypes;

namespace Serilog.Helper.Enrichers
{
    public class TypeEnricher<T> : ILogEventEnricher where T : ILogType
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("LogType", typeof(T).FullName));
        }
    }
}
