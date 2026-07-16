namespace TenderAnalyzer.Infrastructure.Helpers;

public static class JsonCleanupHelper
{
    public static string Clean(string response)
    {
        return response
            .Replace("```json", "")
            .Replace("```", "")
            .Trim();
    }
}