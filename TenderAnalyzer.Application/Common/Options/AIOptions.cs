namespace TenderAnalyzer.Application.Common.Options;

public class AIOptions
{
    public const string SectionName = "AI";

    public string Provider { get; set; } = "Ollama";

    public string BaseUrl { get; set; } = "http://localhost:11434";

    public string ChatModel { get; set; } = "phi3:mini";

    public string EmbeddingModel { get; set; } = "nomic-embed-text:latest";

    public int TimeoutSeconds { get; set; } = 300;
}