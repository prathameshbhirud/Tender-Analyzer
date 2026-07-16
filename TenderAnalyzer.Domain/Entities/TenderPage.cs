namespace TenderAnalyzer.Domain.Entities;

public class TenderPage
{
    public Guid Id { get; set; }

    public Guid TenderId { get; set; }

    public int PageNumber { get; set; }

    public string Content { get; set; } = string.Empty;

    public Tender Tender { get; set; } = null!;
}