using Microsoft.EntityFrameworkCore;
using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Repositories;

public class TenderChunkRepository
    : ITenderChunkRepository
{
    private readonly ApplicationDbContext _db;

    public TenderChunkRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddRangeAsync(IEnumerable<TenderChunk> chunks)
    {
        await _db.TenderChunks.AddRangeAsync(chunks);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }

    public async Task<List<TenderChunk>> GetByTenderIdAsync(Guid tenderId)
    {
        return await _db.TenderChunks
            .Where(x => x.TenderId == tenderId)
            .OrderBy(x => x.ChunkIndex)
            .ToListAsync();
    }
}