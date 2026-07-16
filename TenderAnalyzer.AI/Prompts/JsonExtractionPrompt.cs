namespace TenderAnalyzer.AI.Prompts;

public class JsonExtractionPrompt : IAIPrompt
{
    public string Name => "Json";

    public string Build(string input)
    {
        return
            $$$$"""
            Return ONLY JSON.

            {{
            "title":"",
            "organization":""
            }}

            Text:

            {input}
            """;
    }
}