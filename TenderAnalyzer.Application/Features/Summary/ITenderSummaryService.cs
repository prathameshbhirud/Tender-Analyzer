namespace TenderAnalyzer.Application.Features.Summary;

public interface ITenderSummaryService
{
    Task GenerateAsync(Guid tenderId);

    Task<string?> GetLatestAsync(Guid tenderId);
}