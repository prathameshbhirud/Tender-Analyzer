namespace TenderAnalyzer.AI.Prompting;

public interface IPromptBuilder
{
    string BuildSummaryPrompt(string text);

    string BuildJsonExtractionPrompt(string text);

    string BuildFieldExtractionPrompt(string text, IEnumerable<string> fields);
}