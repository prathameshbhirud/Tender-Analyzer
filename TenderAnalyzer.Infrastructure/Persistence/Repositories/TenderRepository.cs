using Microsoft.EntityFrameworkCore;
using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence.Repositories;

public class TenderRepository: ITenderRepository
{
    private readonly ApplicationDbContext _db;

    public TenderRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Tender?> GetByIdAsync(Guid id)
    {
        return await _db.Tenders.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Tender>> GetAllAsync()
    {
        return await _db.Tenders.OrderByDescending(x => x.UploadedAtUtc).ToListAsync();
    }

    public async Task AddAsync(Tender tender)
    {
        await _db.Tenders.AddAsync(tender);
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
    }

    public Task UpdateAsync(Tender tender)
    {
        _db.Tenders.Update(tender);
        return Task.CompletedTask;
    }
}