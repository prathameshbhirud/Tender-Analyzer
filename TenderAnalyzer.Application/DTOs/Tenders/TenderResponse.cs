using TenderAnalyzer.Domain.Enums;

namespace TenderAnalyzer.Application.DTOs.Tenders;

public class TenderResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string FileName { get; set; } = string.Empty;

    public TenderStatus Status { get; set; }

    public DateTime UploadedAtUtc { get; set; }
}