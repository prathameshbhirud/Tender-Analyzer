namespace TenderAnalyzer.Application.DTOs.Tenders;

public class UploadTenderResponse
{
    public Guid TenderId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}