using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TenderAnalyzer.AI.Models;
using TenderAnalyzer.Application.Common.Options;

namespace TenderAnalyzer.AI.Clients;

public class OllamaClient : IOllamaClient
{
    private readonly HttpClient _httpClient;
    private readonly AIOptions _options;
    private readonly ILogger<OllamaClient> _logger;

    public OllamaClient(HttpClient httpClient, IOptions<AIOptions> options, ILogger<OllamaClient> logger)
    {
        _httpClient = httpClient;
        _options = options.Value;
        _logger = logger;
    }

    public async Task<string> GenerateAsync(string prompt, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Sending prompt to Ollama. Prompt Length: {Length}", prompt.Length);

        var request = new OllamaGenerateRequest
        {
            Model = _options.ChatModel,
            Prompt = prompt,
            Stream = false,
            Options = new OllamaGenerationOptions
            {
                Temperature = 0.2,
                NumPredict = 256
            }
        };

        var response = await _httpClient.PostAsJsonAsync("api/generate", request, cancellationToken);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<OllamaGenerateResponse>(cancellationToken: cancellationToken);

        if (result == null)
        {
            throw new InvalidOperationException("No response received from Ollama.");
        }

        _logger.LogInformation("Received response from Ollama. Response Length: {Length}", result.Response.Length);

        return result.Response;
    }
}