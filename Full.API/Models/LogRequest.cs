namespace Full.API.Models;

public class LogRequest
{
    public required string Message { get; init; }
    public required int Severity { get; init; }
}