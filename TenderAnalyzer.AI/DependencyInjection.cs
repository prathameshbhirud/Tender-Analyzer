using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TenderAnalyzer.AI.Clients;
using TenderAnalyzer.AI.Prompting;
using TenderAnalyzer.AI.Services;
using TenderAnalyzer.Application.Abstractions.AI;
using TenderAnalyzer.Application.Common.Options;

namespace TenderAnalyzer.AI;

public static class DependencyInjection
{
    public static IServiceCollection AddAI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISummaryGenerator, OllamaSummaryGenerator>();
        services.Configure<AIOptions>(configuration.GetSection(AIOptions.SectionName));
        services.AddHttpClient<IOllamaClient, OllamaClient>((serviceProvider, client) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<AIOptions>>()
                .Value;

            client.BaseAddress = new Uri(options.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        });
        services.AddSingleton<IPromptBuilder, PromptBuilder>();

        return services;
    }
}