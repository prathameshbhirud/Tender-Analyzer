namespace TenderAnalyzer.Application.Abstractions.OCR;

public class DocumentProcessingResult
{
    public List<DocumentPage> Pages { get; set; } = new();
}