using Microsoft.Extensions.Options;
using TenderAnalyzer.Application.Abstractions.Storage;
using TenderAnalyzer.Application.Common.Options;

namespace TenderAnalyzer.Infrastructure.Storage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly StorageOptions _options;

    public LocalFileStorageService(IOptions<StorageOptions> options)
    {
        _options = options.Value;
    }

    public async Task<FileStorageResult> SaveAsync(Stream stream, string fileName, CancellationToken cancellationToken = default)
    {
        var now = DateTime.UtcNow;

        var folder = Path.Combine(
            Directory.GetCurrentDirectory(),
            _options.RootPath,
            _options.TenderFolder,
            now.Year.ToString(),
            now.Month.ToString("00"));

        Directory.CreateDirectory(folder);

        var uniqueName = $"{Guid.NewGuid():N}_{fileName}";

        var filePath = Path.Combine(folder, uniqueName);

        await using var fileStream = File.Create(filePath);

        await stream.CopyToAsync(fileStream, cancellationToken);

        return new FileStorageResult
        {
            FilePath = filePath,
            StoredFileName = uniqueName,
            FileSizeBytes = new FileInfo(filePath).Length
        };
    }
}