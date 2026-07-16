using System.Diagnostics;
using TenderAnalyzer.Application.Abstractions.AI;
using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Application.Abstractions.Storage;
using TenderAnalyzer.Application.DTOs.Tenders;
using TenderAnalyzer.Application.Features.Summary;
using TenderAnalyzer.Application.Features.Tenders;
using TenderAnalyzer.Domain.Entities;
using TenderAnalyzer.Domain.Enums;
using TenderAnalyzer.Infrastructure.Helpers;

namespace TenderAnalyzer.Infrastructure.Services;

public class TenderSummaryService : ITenderSummaryService
{
    private readonly ITenderChunkRepository _tenderChunkRepository;
    private readonly ITenderSummaryRepository _tenderSummaryRepository;
    private readonly ISummaryGenerator _summaryGenerator;

    public TenderSummaryService(
        ITenderChunkRepository tenderChunkRepository,
        ITenderSummaryRepository tenderSummaryRepository,
        ISummaryGenerator summaryGenerator)
    {
        _tenderChunkRepository = tenderChunkRepository;
        _tenderSummaryRepository = tenderSummaryRepository;
        _summaryGenerator = summaryGenerator;
    }

    public async Task GenerateAsync(Guid tenderId)
    {
        var chunks = await _tenderChunkRepository.GetByTenderIdAsync(tenderId);

        if (!chunks.Any())
            throw new Exception("No chunks found.");

        // var content = string.Join(Environment.NewLine, chunks.Select(x => x.ChunkText));
        var content = string.Join(Environment.NewLine, chunks.OrderBy(x => x.ChunkIndex).Take(2).Select(x => x.ChunkText));

        // MVP protection
        if (content.Length > 1500)
        {
            content = content.Substring(0, 1500);
        }

        var prompt = $@"
            You are an expert government procurement analyst.

            Analyze the tender and return ONLY VALID JSON.

            Do not return markdown.
            Do not return explanation.
            Do not return code fences.

            Return exactly this structure:

            {{
            ""title"": """",
            ""organization"": """",
            ""submissionDate"": """",
            ""emdAmount"": """",
            ""estimatedValue"": """",
            ""scope"": """",
            ""eligibilityCriteria"": """"
            }}

            Tender:

            {content}";

        var summary = await _summaryGenerator.GenerateSummaryAsync(prompt);
        summary = JsonCleanupHelper.Clean(summary);

        await _tenderSummaryRepository.AddAsync(
            new TenderSummary
            {
                Id = Guid.NewGuid(),
                TenderId = tenderId,
                SummaryJson = summary,
                GeneratedAtUtc = DateTime.UtcNow
            });

        await _tenderSummaryRepository.SaveChangesAsync();
    }

    public async Task<string?> GetLatestAsync(Guid tenderId)
    {
        var summary = await _tenderSummaryRepository.GetLatestAsync(tenderId);
        return summary?.SummaryJson;
    }
}