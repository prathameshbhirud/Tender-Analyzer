namespace TenderAnalyzer.Application.Abstractions.Storage;

public interface IFileStorageService
{
    Task<FileStorageResult> SaveAsync(Stream stream, string fileName, CancellationToken cancellationToken = default);
}