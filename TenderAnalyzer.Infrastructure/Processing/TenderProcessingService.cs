using TenderAnalyzer.Application.Abstractions.Chunking;
using TenderAnalyzer.Application.Abstractions.OCR;
using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Application.Features.Processing;
using TenderAnalyzer.Domain.Entities;
using TenderAnalyzer.Domain.Enums;

namespace TenderAnalyzer.Infrastructure.Processing;

public class TenderProcessingService: ITenderProcessingService
{
    private readonly ITenderRepository _tenderRepository;
    private readonly ITenderPageRepository _pageRepository;
    private readonly IDocumentProcessor _documentProcessor;
    private readonly ITenderChunkRepository _chunkRepository;
    private readonly ITextChunker _chunker;

    public TenderProcessingService(
        ITenderRepository tenderRepository,
        ITenderPageRepository pageRepository,
        ITenderChunkRepository chunkRepository,
        IDocumentProcessor documentProcessor,
        ITextChunker chunker)
    {
        _tenderRepository = tenderRepository;
        _pageRepository = pageRepository;
        _chunkRepository = chunkRepository;
        _documentProcessor = documentProcessor;
        _chunker = chunker;
    }

    public async Task ProcessAsync(Guid tenderId)
    {
        Tender? tender;
        try
        {
            tender = await _tenderRepository.GetByIdAsync(tenderId);

            if (tender == null)
                throw new Exception($"Tender {tenderId} not found");

            tender.Status = TenderStatus.Processing;

            await _tenderRepository.SaveChangesAsync();

            var result = await _documentProcessor.ProcessAsync(tender.FilePath);

            var pages = result.Pages.Select(page =>
                new TenderPage
                {
                    Id = Guid.NewGuid(),
                    TenderId = tender.Id,
                    PageNumber = page.PageNumber,
                    Content = page.Content
                });

            await _pageRepository.AddRangeAsync(pages);

            await _pageRepository.SaveChangesAsync();

            var chunks = new List<TenderChunk>();

            var chunkIndex = 0;

            foreach (var page in result.Pages)
            {
                var pageChunks = _chunker.Chunk(page.PageNumber, page.Content);

                chunks.AddRange(pageChunks.Select(chunk =>
                        new TenderChunk
                        {
                            Id = Guid.NewGuid(),
                            TenderId = tender.Id,
                            PageNumber = chunk.PageNumber,
                            ChunkIndex = ++chunkIndex,
                            ChunkText = chunk.Content,
                            CreatedAtUtc = DateTime.UtcNow
                        }));
            }

            await _chunkRepository.AddRangeAsync(chunks);

            await _chunkRepository.SaveChangesAsync();

            tender.TotalPages = pages.Count();
            tender.TotalChunks = chunks.Count;
            tender.ProcessedAtUtc = DateTime.UtcNow;
            tender.Status = TenderStatus.Processed;

            await _tenderRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            tender = new();
            tender.Status = TenderStatus.Failed;
            tender.ProcessingError = ex.Message;
            await _tenderRepository.SaveChangesAsync();
            throw;
        }
    }
}