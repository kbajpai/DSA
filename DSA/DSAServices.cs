using System.Reflection;
using System.Xml;
using DSA.Common;
using DSA.Config;
using DSA.Logger;
using DSA.Properties;
using DSA.TreesGraphs;
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository.Hierarchy;
using log4net.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.IO.Path;

namespace DSA;

public class DSAServices {
    private const string S_APP_NAME_KEY = "AppName";
    private const string S_APP_SETTINGS_FILE = "appsettings.json";
    private const string S_APP_TAG_KEY = "AppTag";
    private const string S_ASPNETCORE_ENVIRONMENT_KEY = "ASPNETCORE_ENVIRONMENT";
    private const string S_CONFIG_LOG_CONFIG_KEY = "LogConfig";
    private const string S_DEBUG_ON_KEY = "debug";
    private const string S_LOG_CONFIG_FILE = "log4net.config";
    private const string S_LOG_ENVIRONMENT_KEY = "Environment";
    private const string S_LOG_PROP_LOG_FILE_DIRECTORY_KEY = "LogFileDirectory";
    private const string S_LOG_PROP_LOG_FILE_NAME_KEY = "LogFileName";
    private const char S_SLASH_BACKWARD = '\\';
    private const char S_SLASH_FORWARD = '/';

    private static DSAServices? _instance;

    private readonly IConfiguration _configBuilder;
    private readonly IServiceProvider _servicesBuilder;
    private readonly string _appEnvironment;
    private readonly string _appName;
    private readonly string _appTag;

    private DSAServices() {
        _appEnvironment = Environment.GetEnvironmentVariable(S_ASPNETCORE_ENVIRONMENT_KEY) ?? string.Empty;

        _configBuilder = ConfigurationBuilder();

        _appName = _configBuilder.GetValue<string>(S_APP_NAME_KEY) ?? string.Empty;

        _appTag = _configBuilder.GetValue<string>(S_APP_TAG_KEY) ?? string.Empty;

        _configBuilder.GetValue(S_DEBUG_ON_KEY, false);

        _servicesBuilder = ServicesBuilder();
    }

    public static T GetRequiredService<T>() where T : class {
        return GetInstance()!._servicesBuilder.GetRequiredService<T>();
    }

    public static T? GetSetting<T>(string key, T? defaultValue) {
        return GetInstance()!._configBuilder.GetValue(key, defaultValue);
    }

    private static IConfiguration ConfigurationBuilder() {
        var configBuilder = new ConfigurationBuilder()
                .SetBasePath(GetBasePath())
                .AddJsonFile(S_APP_SETTINGS_FILE, true, true)
            ;

        return configBuilder.Build();
    }

    private void ConfigureLog4Net() {
        GlobalContext.Properties[S_APP_TAG_KEY] = _appTag;
        GlobalContext.Properties[S_APP_NAME_KEY] = _appName;
        GlobalContext.Properties[S_LOG_ENVIRONMENT_KEY] = _appEnvironment;
        GlobalContext.Properties[S_LOG_PROP_LOG_FILE_NAME_KEY] = GetLogFileName();
        GlobalContext.Properties[S_LOG_PROP_LOG_FILE_DIRECTORY_KEY] = GetLogsDirectory();

        LogLog.InternalDebugging = GetLogConfig().LogLogEnabled;

        var assemblyLocation = GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var log4NetConfig = new XmlDocument();
        log4NetConfig.Load($"{assemblyLocation}{DirectorySeparatorChar}{S_LOG_CONFIG_FILE}");

        var log4NetRepo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(Hierarchy));

        XmlConfigurator.Configure(log4NetRepo, log4NetConfig["log4net"]);

        //Set the log level
        log4NetRepo.Threshold = GetLogLevel();
    }

    private static string GetBasePath() {
        return GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
               throw new InvalidOperationException($"Unable to set base path in {typeof(DSAServices).FullName}");
    }

    private static DSAServices? GetInstance() {
        if (_instance == null) {
            _instance = new DSAServices();

            //Configure Log4Net
            _instance.ConfigureLog4Net();
        }

        return _instance;
    }

    private LogConfig GetLogConfig() {
        var logConfig = new LogConfig();

        _configBuilder.GetSection(S_CONFIG_LOG_CONFIG_KEY).Bind(logConfig);

        return logConfig;
    }

    private string GetLogFileName() {
        if (string.IsNullOrEmpty(_appName)) {
            var logFilename = GetLogConfig().LogFilename;
            return string.IsNullOrEmpty(logFilename)
                ? Resource.DefaultLogFile
                : logFilename;
        }

        return $"{_appName}.log";
    }

    private Level GetLogLevel() {
        var logLevel = Level.Info;
        try {
            logLevel = GetLogConfig().LogLevel.ToUpper() switch {
                "ALL" => Level.All,
                "DEBUG" => Level.Debug,
                "INFO" => Level.Info,
                "ERROR" => Level.Error,
                "CRITICAL" => Level.Critical,
                _ => Level.Info
            };
        }
        catch (SystemException e) {
            Console.WriteLine(e);
        }

        return logLevel;
    }

    private string GetLogsDirectory() {
        var logDir = string.Empty;

        try {
            logDir = string.IsNullOrEmpty(GetLogConfig().LogsRoot)
                ? GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                : $"{GetLogConfig().LogsRoot}{DirectorySeparatorChar}{_appTag}";
        }
        catch (SystemException e) {
            Console.WriteLine(e);
        }

        return string.IsNullOrEmpty(logDir)
            ? throw new ApplicationException("Error in getting Logs Directory")
            : NormalizeDirectorySeparator(logDir, true);
    }

    private static string NormalizeDirectorySeparator(string fileSystemPath, bool forwardSlash = false,
        bool backSlash = false) {
        char directorySeparator;

        if (backSlash) {
            directorySeparator = S_SLASH_BACKWARD;
        }
        else if (forwardSlash) {
            directorySeparator = S_SLASH_FORWARD;
        }
        else {
            directorySeparator = DirectorySeparatorChar;
        }

        return fileSystemPath
                .Replace(@"//", directorySeparator.ToString())
                .Replace(@"\\", directorySeparator.ToString())
                .Replace(@"/", directorySeparator.ToString())
                .Replace(@"\", directorySeparator.ToString())
            ;
    }

    private IServiceProvider ServicesBuilder() {
        var services = new ServiceCollection();

        services.AddSingleton(_configBuilder);
        services.AddSingleton(typeof(IAppLogger<>), typeof(AppLogger<>));
        services.AddSingleton<IDataWarehouse, DataWarehouse>();
        services.AddSingleton<IBSTServices, BSTServices>();

        return services.BuildServiceProvider();
    }
}