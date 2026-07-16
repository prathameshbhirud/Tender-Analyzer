using Microsoft.EntityFrameworkCore;
using TenderAnalyzer.Domain.Entities;

namespace TenderAnalyzer.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Tender> Tenders => Set<Tender>();

    public DbSet<TenderPage> TenderPages => Set<TenderPage>();

    public DbSet<TenderChunk> TenderChunks => Set<TenderChunk>();

    public DbSet<TenderSummary> TenderSummaries => Set<TenderSummary>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}