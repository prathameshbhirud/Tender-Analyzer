namespace TenderAnalyzer.Domain.Entities;

public class TenderSummary
{
    public Guid Id { get; set; }

    public Guid TenderId { get; set; }

    public string SummaryJson { get; set; } = string.Empty;

    public DateTime GeneratedAtUtc { get; set; }

    public Tender Tender { get; set; } = null!;
}