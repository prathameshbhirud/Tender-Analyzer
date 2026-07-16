using iText.Kernel.Pdf;
using TenderAnalyzer.Application.Abstractions.OCR;

namespace TenderAnalyzer.Infrastructure.OCR;

public class ITextDocumentProcessor : IDocumentProcessor
{
    public Task<DocumentProcessingResult> ProcessAsync(string filePath, CancellationToken cancellationToken = default)
    {
        var result = new DocumentProcessingResult();

        using var reader = new PdfReader(filePath);
        using var pdf = new PdfDocument(reader);

        for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
        {
            var page = pdf.GetPage(i);

            var text = iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(page);

            result.Pages.Add(
                new DocumentPage
                {
                    PageNumber = i,
                    Content = text
                });
        }

        return Task.FromResult(result);
    }
}