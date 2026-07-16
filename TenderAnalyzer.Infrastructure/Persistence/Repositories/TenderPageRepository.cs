using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Repositories;

public class TenderPageRepository : ITenderPageRepository
{
    private readonly ApplicationDbContext _db;

    public TenderPageRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddRangeAsync(IEnumerable<TenderPage> pages)
    {
        await _db.TenderPages.AddRangeAsync(pages);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }
}