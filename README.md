# Serilog.Helper

An experiment to figure out how to use it for multiple log files.

For a project I am working on for fun, I wanted to have different log files to be used based on the service that was logging.

## What I would like

I would like the configuration (either code or appsettings) to be something like this:

```csharp
    .WriteTo.Map("LogType", nameof(ILogType), (logType, writeTo) =>
        writeTo.File(@$"C:\Logs\Experiment\{logType}.log",
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true,
            outputTemplate:
            "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [Thread:({ThreadId:D3})] Message: {Message}{NewLine}{Exception}"))
```

The `.Map` would take the property `LogType` and use its value as the name of the log file.

I would then have an extension that would set the property value.

```csharp
        public static ILogger AsType<T>(this ILogger logger) where T : ILogType
        {
            logger.ForContext("LogType", nameof(T));
            return logger;
        }
```

Then I would call it like this:

```csharp
    _logger.AsType<SystemType>().Information(message);
```

This would take the `SystemType` as the name that would be put into the property of `LogType` which the Map sink would use in the configuration.

## What I was trying to avoid

This is what I didn't want to do.

```csharp
    _logger.Information($"{message} {{LogType}}", nameOf(SystemType));
```

The reason I didn't want to use this, is because the name of the type is the file name, why do I need it in the log message as well.

### However, it works

I have created several extensions which copy the normal Serilog methods.

* Verbose
* Debug
* Information
* Warning
* Error
* Fatal

The extensions look like this (I'm showing the `Information()` version here):

```csharp
    public static void Information<T>(this ILogger logger, string message) where T : ILogType
    {
        logger.Information($"{{LogType}}-{message}", typeof(T).Name);
    }
```

The call to this extension looks like this:

```csharp
    _logger.Information<SystemType>(message);
```

## I also tried this

This was another way I tried to make it work.  The configuration is the same as before.

The extension to set the property was this:

```csharp
    public static void AsType<T>(this ILogger logger, Action<ILogger> logMessage) where T : ILogType
    {
        using (LogContext.PushProperty("LogType", nameof(T)))
        {
            logMessage(logger);
        }
    }
```

This would then be called like this:

```csharp
    _logger.AsType<SystemType>((log) => log.Information(message));
```

Yet, even this way, the `LogType` name was never picked up by the Map sink.

I did expect this version to work, as the context is pushing the property into the log event with the name.  But the Map didn't recognise it as a property because it was not in the actual message itself.  Which is still what I was trying to avoid.

## Sinks

I tried to use the following sinks:

* Map
* File

### Map Sink

This sink I was trying to use to get the property I had defined to set the name of the log file.  It was supposed to match the log file and only write to that.

This didn't work as I wanted it to.  To make this work, I had to have the property written in the message of the event, and have the value of the property in the call to `.Information`, `.Debug`, etc.

I didn't want that.

### File Sink

I needed this sink as I was logging to a file.
