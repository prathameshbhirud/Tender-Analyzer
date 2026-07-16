using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Application.Abstractions.Persistence;

public interface ITenderRepository
{
    Task<Tender?> GetByIdAsync(Guid id);

    Task<List<Tender>> GetAllAsync();

    Task AddAsync(Tender tender);

    Task SaveChangesAsync();

    Task UpdateAsync(Tender tender);
}