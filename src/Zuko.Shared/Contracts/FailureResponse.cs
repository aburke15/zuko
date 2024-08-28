namespace Zuko.Shared.Contracts;

public class FailureResponse
{
    public bool Success { get; init; } = false;
    public string Message { get; set; }
}
