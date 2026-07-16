using TenderAnalyzer.Application.DTOs.Tenders;

namespace TenderAnalyzer.Application.Features.Tenders;

public interface ITenderService
{
    Task<Guid> CreateAsync(CreateTenderRequest request);

    Task<List<TenderResponse>> GetAllAsync();

    Task<TenderResponse?> GetByIdAsync(Guid id);

    Task<UploadTenderResponse> UploadAsync(Stream stream, string fileName);
}