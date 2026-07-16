namespace TenderAnalyzer.AI.Prompts;

public interface IAIPrompt
{
    string Name { get; }

    string Build(string input);
}