using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TenderAnalyzer.Application.Abstractions.Chunking;
using TenderAnalyzer.Application.Abstractions.OCR;
using TenderAnalyzer.Application.Abstractions.Persistence;
using TenderAnalyzer.Application.Abstractions.Storage;
using TenderAnalyzer.Application.Common.Options;
using TenderAnalyzer.Application.Features.Processing;
using TenderAnalyzer.Application.Features.Summary;
using TenderAnalyzer.Application.Features.Tenders;
using TenderAnalyzer.Infrastructure.Chunking;
using TenderAnalyzer.Infrastructure.OCR;
using TenderAnalyzer.Infrastructure.Persistence;
using TenderAnalyzer.Infrastructure.Persistence.Repositories;
using TenderAnalyzer.Infrastructure.Processing;
using TenderAnalyzer.Infrastructure.Services;
using TenderAnalyzer.Infrastructure.Storage;

namespace TenderAnalyzer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        // Options
        services.Configure<StorageOptions>(configuration.GetSection(StorageOptions.SectionName));

        // Repositories
        services.AddScoped<ITenderRepository, TenderRepository>();
        services.AddScoped<ITenderPageRepository, TenderPageRepository>();
        services.AddScoped<ITenderChunkRepository, TenderChunkRepository>();
        services.AddScoped<ITenderSummaryRepository, TenderSummaryRepository>();

        // Services
        services.AddScoped<ITenderService, TenderService>();
        services.AddScoped<ITenderProcessingService, TenderProcessingService>();
        services.AddScoped<IDocumentProcessor, ITextDocumentProcessor>();
        services.AddScoped<ITextChunker, FixedSizeTextChunker>();
        services.AddScoped<ITenderSummaryService, TenderSummaryService>();

        // Storage
        services.AddScoped<IFileStorageService, LocalFileStorageService>();

        return services;
    }
}