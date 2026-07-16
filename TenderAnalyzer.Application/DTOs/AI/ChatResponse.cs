namespace TenderAnalyzer.Application.DTOs.AI;

public class ChatResponse
{
    public string Response { get; set; } = string.Empty;

    public long ElapsedMilliseconds { get; set; }
}