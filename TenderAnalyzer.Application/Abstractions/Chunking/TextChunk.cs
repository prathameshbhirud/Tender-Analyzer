namespace TenderAnalyzer.Application.Abstractions.Chunking;

public class TextChunk
{
    public int PageNumber { get; set; }

    public string Content { get; set; } = string.Empty;
}