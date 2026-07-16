using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using TenderAnalyzer.AI.Models;
using TenderAnalyzer.Application.Abstractions.AI;

namespace TenderAnalyzer.AI.Services;

public class OllamaSummaryGenerator : ISummaryGenerator
{
    private readonly HttpClient _httpClient;

    public OllamaSummaryGenerator(IHttpClientFactory factory){
        _httpClient = factory.CreateClient();
    }

    public async Task<string> GenerateSummaryAsync(string documentContent, CancellationToken cancellationToken = default)
    {
        var request = new
        {
            model = "phi3:mini",
            prompt = "Say hello in one sentence.",
            stream = false
        };

        var sw = Stopwatch.StartNew();
        Console.WriteLine($"Sending prompt length: {documentContent.Length}");

        var response = await _httpClient.PostAsJsonAsync(
                "http://localhost:11434/api/generate",
                request,
                cancellationToken);

        sw.Stop();
        Console.WriteLine($"Ollama response received in {sw.Elapsed}");

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<OllamaGenerateResponse>(cancellationToken);
        return result?.Response ?? string.Empty;
    }
}