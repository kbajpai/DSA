using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DSA.Config;

public sealed class LogConfig {
    [RegularExpression(@"^(ALL|DEBUG|INFO|ERROR|CRITICAL|OFF)$")]
    [JsonProperty(nameof(LogLevel))]
    public string LogLevel { get; set; } = "ERROR";

    [RegularExpression(
        @"^((?:[a-zA-Z]:/|/)?(?:[^<>:""/\\|?*]*)|([a-zA-Z]:\\(((?![<>:""""/\\|?*]).)+((?<![ .])\\)?)*|/|(/[a-zA-Z0-9_-]+)+))$")]
    [JsonProperty(nameof(LogsRoot))]
    [Required]
    public string LogsRoot { get; set; } = "Logs";

    [RegularExpression(@"^[\w,\s-]+\.[A-Za-z]{3}$")]
    [JsonProperty(nameof(LogFilename))]
    public string LogFilename { get; set; } = "AppLog.log";

    [Range(typeof(bool), "false", "true")]
    [JsonProperty(nameof(DatabaseLogging))]
    public bool DatabaseLogging { get; set; }

    [Range(typeof(bool), "false", "true")]
    [JsonProperty(nameof(LogLogEnabled))]
    public bool LogLogEnabled { get; set; }
}