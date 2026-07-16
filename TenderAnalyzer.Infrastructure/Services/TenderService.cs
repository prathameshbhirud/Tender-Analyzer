using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Application.Abstractions.Storage;
using TenderAnalyzer.Application.DTOs.Tenders;
using TenderAnalyzer.Application.Features.Tenders;
using TenderAnalyzer.Domain.Entities;
using TenderAnalyzer.Domain.Enums;

namespace TenderAnalyzer.Infrastructure.Services;

public class TenderService : ITenderService
{
    private readonly ITenderRepository _repository;

    private readonly IFileStorageService _fileStorageService;

    public TenderService(
        ITenderRepository repository,
        IFileStorageService fileStorageService)
    {
        _repository = repository;
        _fileStorageService = fileStorageService;
    }

    public async Task<Guid> CreateAsync(CreateTenderRequest request)
    {
        var tender = new Tender
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Status = TenderStatus.Uploaded,
            UploadedAtUtc = DateTime.UtcNow
        };

        await _repository.AddAsync(tender);
        await _repository.SaveChangesAsync();

        return tender.Id;
    }

    public async Task<List<TenderResponse>> GetAllAsync()
    {
        var tenders = await _repository.GetAllAsync();

        return tenders.Select(x => new TenderResponse
        {
            Id = x.Id,
            Name = x.Name,
            FileName = x.FileName,
            Status = x.Status,
            UploadedAtUtc = x.UploadedAtUtc
        }).ToList();
    }

    public async Task<TenderResponse?> GetByIdAsync(Guid id)
    {
        var tender = await _repository.GetByIdAsync(id);

        if (tender == null)
            return null;

        return new TenderResponse
        {
            Id = tender.Id,
            Name = tender.Name,
            FileName = tender.FileName,
            Status = tender.Status,
            UploadedAtUtc = tender.UploadedAtUtc
        };
    }

    public async Task<UploadTenderResponse> UploadAsync(Stream stream, string fileName)
    {
        var fileStorageResult = await _fileStorageService.SaveAsync(stream, fileName);

        var tender = new Tender
        {
            Id = Guid.NewGuid(),
            Name = Path.GetFileNameWithoutExtension(fileName),
            FileName = fileName,
            FilePath = fileStorageResult.FilePath,
            Status = TenderStatus.Uploaded,
            UploadedAtUtc = DateTime.UtcNow
        };

        await _repository.AddAsync(tender);

        await _repository.SaveChangesAsync();

        return new UploadTenderResponse
        {
            TenderId = tender.Id,
            FileName = fileName,
            FilePath = fileStorageResult.FilePath
        };
    }
}