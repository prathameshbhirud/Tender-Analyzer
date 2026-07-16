namespace TenderAnalyzer.Application.Abstractions.OCR;

public interface IDocumentProcessor
{
    Task<DocumentProcessingResult> ProcessAsync(string filePath, CancellationToken cancellationToken = default);
}