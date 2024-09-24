namespace Core;

using Core.Contracts;

public class LogWriter : ILogWriter
{
    public async Task<string> WriteAsync(int severity, string message, CancellationToken cancellationToken)
    {
        var today = DateTime.Today.ToString("yyyyMMdd");
        var uniqueKey = Guid.NewGuid().ToString();
        var logId = $"{today}-{uniqueKey}";

        await File.WriteAllTextAsync($"./{logId}.log", $"[{severity}] {message}", cancellationToken);
        return logId;
    }
}