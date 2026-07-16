using System.Text.Json.Serialization;

namespace TenderAnalyzer.AI.Models;

public class OllamaGenerateResponse
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = string.Empty;

    [JsonPropertyName("response")]
    public string Response { get; set; } = string.Empty;

    [JsonPropertyName("done")]
    public bool Done { get; set; }
}