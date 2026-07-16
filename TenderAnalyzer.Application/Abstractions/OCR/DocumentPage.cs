namespace TenderAnalyzer.Application.Abstractions.OCR;

public class DocumentPage
{
    public int PageNumber { get; set; }

    public string Content { get; set; } = string.Empty;
}