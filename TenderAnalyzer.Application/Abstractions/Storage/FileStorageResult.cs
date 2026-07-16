namespace TenderAnalyzer.Application.Abstractions.Storage;

public class FileStorageResult
{
    public string FilePath { get; set; } = string.Empty;

    public string StoredFileName { get; set; } = string.Empty;

    public long FileSizeBytes { get; set; }
}