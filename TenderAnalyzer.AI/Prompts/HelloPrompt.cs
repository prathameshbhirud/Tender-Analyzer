namespace TenderAnalyzer.AI.Prompts;

public class HelloPrompt : IAIPrompt
{
    public string Name => "Hello";

    public string Build(string input)
    {
        return "Say hello in one sentence.";
    }
}