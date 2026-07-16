namespace TenderAnalyzer.Application.DTOs.AI;

public class ExtractFieldsRequest
{
    public string Text { get; set; } = string.Empty;

    public List<string> Fields { get; set; } = [];
}