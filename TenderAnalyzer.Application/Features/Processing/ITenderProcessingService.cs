namespace TenderAnalyzer.Application.Features.Processing;

public interface ITenderProcessingService
{
    Task ProcessAsync(Guid tenderId);
}