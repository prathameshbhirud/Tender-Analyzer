namespace TenderAnalyzer.AI.Models;

public class OllamaGenerateRequest
{
    public string Model { get; set; } = string.Empty;

    public string Prompt { get; set; } = string.Empty;

    public bool Stream { get; set; } = false;

    public OllamaGenerationOptions? Options { get; set; } = new();
}

public class OllamaGenerationOptions
{
    public int NumPredict { get; set; } = 512;

    public double Temperature { get; set; } = 0.2;
}