using TenderAnalyzer.Application.Abstractions.OCR;

namespace TenderAnalyzer.Infrastructure.OCR;

public class MockDocumentProcessor : IDocumentProcessor
{
    public async Task<DocumentProcessingResult> ProcessAsync(string filePath, CancellationToken cancellationToken = default)
    {
        await Task.Delay(500);

        return new DocumentProcessingResult
        {
            Pages =
            [
                new DocumentPage
                {
                    PageNumber = 1,
                    Content = $"Mock extracted text from {Path.GetFileName(filePath)}"
                }
            ]
        };
    }
}