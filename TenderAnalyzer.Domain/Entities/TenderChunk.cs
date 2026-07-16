namespace TenderAnalyzer.Domain.Entities;

public class TenderChunk
{
    public Guid Id { get; set; }

    public Guid TenderId { get; set; }

    public int PageNumber { get; set; }

    public string ChunkText { get; set; } = string.Empty;

    public Tender Tender { get; set; } = null!;

    public int ChunkIndex { get; set; }

    public DateTime CreatedAtUtc { get; set; }
}