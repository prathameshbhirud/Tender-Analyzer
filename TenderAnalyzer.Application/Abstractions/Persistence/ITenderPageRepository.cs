using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Application.Abstractions.Persistence;

public interface ITenderPageRepository
{
    Task AddRangeAsync(IEnumerable<TenderPage> pages);

    Task SaveChangesAsync();
}