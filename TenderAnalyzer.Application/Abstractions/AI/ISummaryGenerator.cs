namespace TenderAnalyzer.Application.Abstractions.AI;

public interface ISummaryGenerator
{
    Task<string> GenerateSummaryAsync(string documentContent, CancellationToken cancellationToken = default);
}