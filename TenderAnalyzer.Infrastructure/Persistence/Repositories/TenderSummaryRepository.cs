using Microsoft.EntityFrameworkCore;
using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Repositories;

public class TenderSummaryRepository
    : ITenderSummaryRepository
{
    private readonly ApplicationDbContext _db;

    public TenderSummaryRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(TenderSummary summary)
    {
        await _db.TenderSummaries.AddAsync(summary);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }

    public async Task<TenderSummary?> GetLatestAsync(Guid tenderId)
    {
        return await _db.TenderSummaries
            .Where(x => x.TenderId == tenderId)
            .OrderByDescending(x => x.GeneratedAtUtc)
            .FirstOrDefaultAsync();
    }
}