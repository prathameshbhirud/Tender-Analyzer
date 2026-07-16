using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Application.Abstractions.Persistence;

public interface ITenderChunkRepository
{
    Task AddRangeAsync(IEnumerable<TenderChunk> chunks);

    Task SaveChangesAsync();

    Task<List<TenderChunk>> GetByTenderIdAsync(Guid tenderId);
}