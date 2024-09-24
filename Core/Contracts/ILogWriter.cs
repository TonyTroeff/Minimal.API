namespace Core.Contracts;

public interface ILogWriter
{
    Task<string> WriteAsync(int severity, string message, CancellationToken cancellationToken);
}