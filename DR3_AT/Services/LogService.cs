namespace DR3_AT.Services;

public class LogService
{
    private static readonly List<string> _memoryLogs = new List<string>();

    public void LogToConsole(string message)
    {
        Console.WriteLine($"[CONSOLE LOG]: {message}");
    }

    public void LogToFile(string message)
    {
        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] - {message}{Environment.NewLine}";
        File.AppendAllText("system_log.txt", logMessage);
    }

    public void LogToMemory(string message)
    {
        _memoryLogs.Add(message);
    }
}