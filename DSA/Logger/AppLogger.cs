using log4net;
using log4net.Appender;

namespace DSA.Logger;

internal class AppLogger<T> : IAppLogger<T>
{
    private readonly ILog _typedLogger = LogManager.GetLogger(typeof(T));

    public void Debug(string message)
    {
        _typedLogger.Debug(message);
    }

    public void Debug(string message, Exception exception)
    {
        _typedLogger.Debug(message, exception);
    }

    public void DebugFormat(string format, params object[] args)
    {
        _typedLogger.DebugFormat(format, args);
    }

    public void Error(string message)
    {
        _typedLogger.Error(message);
    }

    public void Error(string message, Exception exception)
    {
        _typedLogger.Error(message, exception);
    }

    public void ErrorFormat(string format, params object[] args)
    {
        _typedLogger.ErrorFormat(format, args);
    }

    public void Fatal(string message)
    {
        _typedLogger.Fatal(message);
    }

    public void Fatal(string message, Exception exception)
    {
        _typedLogger.Fatal(message, exception);
    }

    public void FatalFormat(string format, params object[] args)
    {
        _typedLogger.FatalFormat(format, args);
    }

    public string GetLogFilename()
    {
        var filename = string.Empty;

        try
        {
            filename = LogManager.GetRepository().GetAppenders().OfType<FileAppender>().Single().File;
        }
        catch (SystemException e)
        {
            _typedLogger.Error($"Unable cannot be found filepath for Log. Error = {e.Message}", e);
        }

        return string.IsNullOrEmpty(filename)
            ? throw new ApplicationException("Error in getting Application Environment")
            : filename;
    }

    public void Info(string message)
    {
        _typedLogger.Info(message);
    }

    public void Info(string message, Exception exception)
    {
        _typedLogger.Info(message, exception);
    }

    public void InfoFormat(string format, params object[] args)
    {
        _typedLogger.InfoFormat(format, args);
    }

    public void Warn(string message)
    {
        _typedLogger.Warn(message);
    }

    public void Warn(string message, Exception exception)
    {
        _typedLogger.Warn(message, exception);
    }

    public void WarnFormat(string format, params object[] args)
    {
        _typedLogger.WarnFormat(format, args);
    }
}