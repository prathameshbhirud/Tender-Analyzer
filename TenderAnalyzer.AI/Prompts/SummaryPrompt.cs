namespace TenderAnalyzer.AI.Prompts;

public class SummaryPrompt : IAIPrompt
{
    public string Name => "Summary";

    public string Build(string input)
    {
        return
            $"""
            Summarize the following text.

            Maximum 25 words.

            {input}
            """;
    }
}