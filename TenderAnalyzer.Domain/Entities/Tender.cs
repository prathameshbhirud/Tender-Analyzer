using TenderAnalyzer.Domain.Entities;
using TenderAnalyzer.Domain.Enums;

public class Tender
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public long FileSizeBytes { get; set; }

    public string ContentType { get; set; } = string.Empty;

    public TenderStatus Status { get; set; }

    public DateTime UploadedAtUtc { get; set; }

    public DateTime? ProcessedAtUtc { get; set; }

    public ICollection<TenderPage> Pages { get; set; } = new List<TenderPage>();

    public ICollection<TenderChunk> Chunks { get; set; } = new List<TenderChunk>();

    public ICollection<TenderSummary> Summaries { get; set; } = new List<TenderSummary>();

    public int TotalPages { get; set; }

    public int TotalChunks { get; set; }

    public string? ProcessingError { get; set; }
}