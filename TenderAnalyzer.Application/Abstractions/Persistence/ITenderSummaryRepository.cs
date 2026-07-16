using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Application.Abstractions.Persistence;

public interface ITenderSummaryRepository
{
    Task AddAsync(TenderSummary summary);

    Task SaveChangesAsync();

    Task<TenderSummary?> GetLatestAsync(Guid tenderId);
}